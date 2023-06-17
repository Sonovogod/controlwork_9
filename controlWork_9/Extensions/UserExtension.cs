using controlWork_9.Models;
using controlWork_9.ViewModels.Users;

namespace controlWork_9.Extensions;

public static class UserExtension
{
    public static User MapToUserModel(this UserRegisterViewModel model)
    {
        return new User()
        {
            Email = model.Email,
            Avatar = model.Avatar,
            UserName = model.UserName
        };
    }

    public static UserProfileViewModel MapToShortUserViewModel(this User model)
    {
        return new UserProfileViewModel()
        {
            Id = model.Id,
            Avatar = model.Avatar,
            Email = model.Email,
            Login = model.UserName,
            Balance = model.Balance
        };
    }

    public static ProfileViewModel MapToProfileViewModel(this User user)
    {
        return new ProfileViewModel()
        {
            UserProfile = user.MapToShortUserViewModel(),
        };
    }
}