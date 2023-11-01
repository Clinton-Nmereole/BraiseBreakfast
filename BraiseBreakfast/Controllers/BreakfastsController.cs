using Microsoft.AspNetCore.Mvc;
using BraiseBreakfast.Contracts.Breakfast;
using BraiseBreakfast.Models;
using BraiseBreakfast.Services.Breakfasts;
namespace BreakfastBreakfast.Controllers;

[ApiController]
[Route("breakfast")]
public class BreakfastController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost()]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = new Breakfast(new Guid(), request.Name, request.Description,
                                      request.ImageUrl, request.StartDateTime,
                                      request.EndDateTime, DateTime.UtcNow,
                                      request.Savory, request.Sweet);
        // ToDo: Save the Breakfast to the database
        _breakfastService.CreateBreakfast(breakfast);

        var response = new BreakfastResponse(
            breakfast.Id, breakfast.Name, breakfast.Description, breakfast.ImageUrl,
            breakfast.StartDateTime, breakfast.EndDateTime, breakfast.LastModified,
            breakfast.Savory, breakfast.Sweet);
        return CreatedAtAction(nameof(GetBreakfast), new { id = breakfast.Id },
                               (response));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        Breakfast breakfast = _breakfastService.GetBreakfast(id);
        var response = new BreakfastResponse(
            breakfast.Id, breakfast.Name, breakfast.Description, breakfast.ImageUrl,
            breakfast.StartDateTime, breakfast.EndDateTime, breakfast.LastModified,
            breakfast.Savory, breakfast.Sweet);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsetBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id) { return Ok(id); }
}
