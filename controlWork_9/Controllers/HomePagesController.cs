using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.Controllers;
[Authorize]
public class HomePagesController : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Main()
    {
        return View();
    }
}