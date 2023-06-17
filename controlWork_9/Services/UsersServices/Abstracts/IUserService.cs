using controlWork_9.Models;
using controlWork_9.ViewModels.Users;
using Microsoft.AspNetCore.Identity;

namespace controlWork_9.Services.UsersServices.Abstracts;

public interface IUserService
{
    Task<User?> FindByEmailOrLoginAsync(string? key);
    Task<IdentityResult> Add(UserRegisterViewModel model);
    public bool UserEmailUnique(string email);
    bool UserLoginUnique(string email);
}