using System.Text.RegularExpressions;
using controlWork_9.Extensions;
using controlWork_9.Models;
using controlWork_9.Services.UsersServices.Abstracts;
using controlWork_9.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace controlWork_9.Services.UsersServices;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly WalletDbContext _db;

    public UserService(UserManager<User> userManager, WalletDbContext db)
    {
        _userManager = userManager;
        _db = db;
    }

    public async Task<User?> FindByEmailOrLoginAsync(string? key)
    {
        User? user = new User();
        try
        {
            if (key is null)
                return null;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool isMail = Regex.IsMatch(key, pattern);

            if (isMail)
                user = await _db.Users
                    .FirstOrDefaultAsync(x => x.Email != null && x.Email.ToLower().Equals(key.ToLower()));
            else
                user = await _db.Users
                    .FirstOrDefaultAsync(x => x.UserName != null && x.UserName.Equals(key));
        }
        catch (Exception e)
        {
            return user;
        }

        return user;
    }

    public async Task<IdentityResult> Add(UserRegisterViewModel model)
    {
        User user = model.MapToUserModel();
        user.DateOfCreate = DateTime.Now;
        user.Balance = 100000;
        IdentityResult result = await _userManager.CreateAsync(user, model.Password);
        
        return result;
    }

    public bool UserEmailUnique(string email) 
        => !_userManager.Users.Any(x => x.Email != null && x.Email.ToLower().Equals(email.ToLower()));
    
    public bool UserLoginUnique(string userName)
        => !_userManager.Users.Any(x => x.UserName != null && x.UserName.ToLower().Equals(userName.ToLower()));

    public async Task<User?> FindByIdAsync(string? modelId)
    {
        User? user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == modelId);
        return user;
    }
}