using Microsoft.AspNetCore.Mvc;
using BraiseBreakfast.Contracts.Breakfast;
namespace BreakfastBreakfast.Controllers;

[ApiController]
public class BreakfastController : ControllerBase
{
    [HttpPost("/breakfast")]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/breakfast/{id:guid}")]
    public IActionResult GetBreakfast(Guid id) { return Ok(id); }

    [HttpPut("/breakfast/{id:guid}")]
    public IActionResult UpsetBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/breakfast/{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id) { return Ok(id); }
}
