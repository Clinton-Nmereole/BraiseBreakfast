using Microsoft.AspNetCore.Mvc;
namespace BraiseBreakfast.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() => Problem();
}
