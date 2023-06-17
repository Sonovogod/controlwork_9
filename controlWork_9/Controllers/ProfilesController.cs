using controlWork_9.Extensions;
using controlWork_9.Models;
using controlWork_9.Services.UsersServices.Abstracts;
using controlWork_9.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.Controllers;

[Authorize]
public class ProfilesController : Controller
{
    private readonly IUserService _userService;

    public ProfilesController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Profile(string? userName)
    {
        if (userName is null || User.Identity.Name != userName) 
            return NotFound();

        User? totalUser = await _userService.FindByEmailOrLoginAsync(userName);
        ProfileViewModel model = totalUser.MapToProfileViewModel();
        
        return View(model);
    }

}