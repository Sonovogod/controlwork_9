using controlWork_9.Enums.File;
using controlWork_9.Models;
using controlWork_9.Services.FilesServices.Abstracts;
using controlWork_9.Services.UsersServices.Abstracts;
using controlWork_9.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly SignInManager<User> _signInManager;
    private readonly IFileService _fileService;

    public AccountController(IUserService userService, SignInManager<User> signInManager, IFileService fileService)
    {
        _userService = userService;
        _signInManager = signInManager;
        _fileService = fileService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string? returnUrl)
    {
        if (User.Identity.IsAuthenticated)
            return RedirectToAction("Profile", "Profiles", new { userName = User.Identity.Name });
        return View(new UserLoginViewModel {ReturnUrl = returnUrl});
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(UserLoginViewModel model)
    {
        if (User.Identity.IsAuthenticated)
            return RedirectToAction("Profile", "Profiles", new { userName = User.Identity.Name });
        if (ModelState.IsValid)
        {
            User? user = await _userService.FindByEmailOrLoginAsync(model.EmailOrLogin);
            if (user is not null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

                if (signInResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Profile", "Profiles", new { userName = user.UserName });
                }

            }

            ModelState.AddModelError("incorrectAuthentication", "Некорректный Email/Номер счета и/или пароль");
        }

        return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        if (User.Identity.IsAuthenticated)
            return RedirectToAction("Profile","Profiles", new { userName = User.Identity.Name });
        UserRegisterViewModel model = new UserRegisterViewModel();
        return View(model);
    }
    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegisterViewModel model, IFormFile? uploadedFile)
    {
        if (ModelState.IsValid)
        {
            bool fileValid = _fileService.FileValid(uploadedFile, ImageType.Logo);
            if (fileValid)
            {
                string filePath = _fileService.SaveImage(uploadedFile, ImageType.Logo);
                model.Avatar = filePath;
            }
            else
            {
                string filePath = _fileService.GetPrimalImgPath();
                model.Avatar = filePath;
                ModelState.AddModelError("incorrectLogo", "Не удалось загрузить добавляемое фото, фото не соответсвует требованиям, будет загружено стандартное");
            }
            
            var result = await _userService.Add(model);
            if (result.Succeeded)
            {
                User? user = await _userService.FindByEmailOrLoginAsync(model.Email);
                await _signInManager.SignInAsync(user, true);
                return RedirectToAction("Profile", "Profiles", new {userName = user.UserName});
            }
            ModelState.AddModelError("CreateUserError", "Ошибка при создании пользователя");
        }
        ModelState.AddModelError("incorrectRegistration", "Ошибка регистрации!");

        return View(model);
    }
    
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogOff()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}