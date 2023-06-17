using System.ComponentModel.DataAnnotations;

namespace controlWork_9.ViewModels.Users;

public class UserLoginViewModel
{
    [Display(Name = "Электронная почта или номер счета")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string EmailOrLogin { get; set; }
    
    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public string Password { get; set; }
    public string? ReturnUrl { get; set; }
}