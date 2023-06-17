using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.ViewModels.Users;

public class UserRegisterViewModel
{

    [Display(Name = "Номер счета")]
    [StringLength(15, MinimumLength = 6, ErrorMessage = "Минимальное количество знаков: 6, Максимальное - 15")]
    [Required(ErrorMessage = "Поле не можен быть пустым")]
    [Remote("CheckUniqueLogin", "AccountValidation", ErrorMessage = "Такой лицевой счет уже используется", AdditionalFields = "UserName")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Можно использовать только цифры")]
    public string UserName { get; set; }
    
    [Display(Name = "Эл. почта")]
    [Required(ErrorMessage = "Поле не можен быть пустым")]
    [EmailAddress (ErrorMessage = "Некорректный адрес")]
    [RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Неверный формат ввода")]
    [Remote("CheckUniqueEmail", "AccountValidation", ErrorMessage = "Такая почта уже зарегистрирована", AdditionalFields = "Email")]
    public string Email { get; set; }
    
    [Display(Name = "Фото профиля")]
    public string? Avatar { get; set; }
    
    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [MinLength(5, ErrorMessage = "Минимальная длина поля должна быть не менее 5 символов.")]
    public string Password { get; set; }
    
    [Display(Name = "Подтверждение пароля")]
    [Required(ErrorMessage = "Поле не можен быть пустым")]
    [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
    public string ConfirmPassword { get; set; }

    public string? ReturnUrl { get; set; }
}