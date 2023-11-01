using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using BraiseBreakfast.Contracts.Breakfast;
using BraiseBreakfast.Models;
using BraiseBreakfast.Services.Breakfasts;
using BraiseBreakfast.ServiceErrors;
namespace BraiseBreakfast.Controllers;

public class BreakfastController : ApiController
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost()]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.From(request);
        if (requestToBreakfastResult.IsError)
        {
            return Problem(requestToBreakfastResult.Errors);
        }
        // ToDo: Save the Breakfast to the database
        var breakfast = requestToBreakfastResult.Value;
        ErrorOr<Created> createdBreakfastResult =
            _breakfastService.CreateBreakfast(breakfast);

        if (createdBreakfastResult.IsError)
        {
            return Problem(errors: createdBreakfastResult.Errors);
        }

        return createdBreakfastResult.Match(
            created => CreatedAtGetBreakfast(breakfast), errors => Problem(errors));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);
        return getBreakfastResult.Match(breakfast =>
                                            Ok(MapBreakfastResponse(breakfast)),
                                        errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsetBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.From(id, request);

        if (requestToBreakfastResult.IsError)
        {
            return Problem(requestToBreakfastResult.Errors);
        }

        var breakfast = requestToBreakfastResult.Value;
        ErrorOr<UpsertedBreakfast> upsertBreakfastResult =
            _breakfastService.UpsertBreakfast(breakfast);

        return upsertBreakfastResult.Match(
            upserted => upserted.isNewlyCreated ? CreatedAtGetBreakfast(breakfast)
                                                : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        ErrorOr<Deleted> deleteBreakfastResult =
            _breakfastService.DeleteBreakfast(id);
        return deleteBreakfastResult.Match(deleted => NoContent(),
                                           errors => Problem(errors));
    }

    private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
    {
        return new BreakfastResponse(
            breakfast.Id, breakfast.Name, breakfast.Description, breakfast.ImageUrl,
            breakfast.StartDateTime, breakfast.EndDateTime, breakfast.LastModified,
            breakfast.Savory, breakfast.Sweet);
    }

    private CreatedAtActionResult CreatedAtGetBreakfast(Breakfast breakfast)
    {
        return CreatedAtAction(actionName: nameof(GetBreakfast),
                               routeValues: new { id = breakfast.Id },
                               value: MapBreakfastResponse(breakfast));
    }
}
