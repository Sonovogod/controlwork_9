using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.ViewModels.Accounts;

public class TopUpAccountViewModel
{
    public string? UseName { get; set; }
    
    [Display(Name = "Сумма")]
    [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Только положительные числа")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public decimal Summ { get; set; }
    
    [Display(Name = "Номер счета")]
    [Remote("CheckExistCurrency", "TransactionsValidation", ErrorMessage = "Лицевой счет не найден", AdditionalFields = "AccountNumber, UseName")]
    public string? AccountNumber { get; set; }
}