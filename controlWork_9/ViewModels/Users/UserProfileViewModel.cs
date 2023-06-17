using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.ViewModels.Users;

public class UserProfileViewModel
{
    public string? Id { get; set; }
    [Display(Name = "Фото профиля")]
    public string? Avatar { get; set; }
    
    [Display(Name = "Имя")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Минимальное количество знаков: 1, Максимальное - 30")]
    [Required(ErrorMessage = "Поле не можен быть пустым")]
    [RegularExpression(@"^(?!^\s+$)[a-zA-Zа-яА-Я\s]+$", ErrorMessage = "Не допускается использование спец. символов, цифр и знаков припинания")]
    public string Name { get; set; }
    
    [Display(Name = "Эл. почта")]
    [Required(ErrorMessage = "Поле не можен быть пустым")]
    [EmailAddress (ErrorMessage = "Некорректный адрес")]
    [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Неверный формат ввода")]
    [Remote("CheckUniqueEmailForEditProfile", "AccountValidation", ErrorMessage = "Такая почта уже зарегистрирована", AdditionalFields = "NewEmail, Id")]
    public string Email { get; set; }

    [Display(Name = "Логин")]
    [Required(ErrorMessage = "Поле не можен быть пустым")]
    [StringLength(30, ErrorMessage = "Максимальное количество знаков: 30")]
    [Remote("CheckUniqueLoginForEditProfile", "AccountValidation", ErrorMessage = "Такой логин уже зарегистрирован", AdditionalFields = "Login, Id")]
    [RegularExpression(@"^(?!^\s+$)[a-zA-Z\s]+$", ErrorMessage = "Не допускается использование спец. символов, цифр, знаков припинания и только латинские буквы")]
    public string Login { get; set; }

    [Display(Name = "Введите старый пароль")]
    [MinLength(5, ErrorMessage = "Минимальная длина поля должна быть не менее 5 символов.")]
    public string? OldPassword { get; set; }
    
    [Display(Name = "Введите новый пароль")]
    [MinLength(5, ErrorMessage = "Минимальная длина поля должна быть не менее 5 символов.")]
    public string? NewPassword { get; set; }
    
    [Display(Name = "Подтверждение нового пароля")]
    [Compare(nameof(NewPassword), ErrorMessage = "Пароли не совпадают")]
    public string? ConfirmPassword { get; set; }
    
    public decimal Balance { get; set; }
}