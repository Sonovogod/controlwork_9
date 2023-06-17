using controlWork_9.Services.UsersServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.Controllers;

public class AccountValidationController : Controller
{
    private readonly IUserService _service;

    public AccountValidationController(IUserService service)
    {
        _service = service;
    }

    [AcceptVerbs("GET", "POST")]
    public bool CheckUniqueEmail(string email)
        => _service.UserEmailUnique(email);
    
    [AcceptVerbs("GET", "POST")]
    public bool CheckUniqueLogin(string userName)
        => _service.UserLoginUnique(userName);
}