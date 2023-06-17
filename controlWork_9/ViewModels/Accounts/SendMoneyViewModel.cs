using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.ViewModels.Accounts;

public class SendMoneyViewModel
{
    public string UserName { get; set; }
    
    [Display(Name = "Сумма")]
    [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Только положительные числа")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Remote("CheckExisMoney", "TransactionsValidation", ErrorMessage = "Недостаточно средств", AdditionalFields = "Summ, UserName")]
    public decimal Summ { get; set; }
    
    [Display(Name = "Кому отправить")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Remote("CheckExistCurrency", "TransactionsValidation", ErrorMessage = "Лицевой счет не найден", AdditionalFields = "AccountNumber, UseName")]
    public string AccountNumber { get; set; }
}