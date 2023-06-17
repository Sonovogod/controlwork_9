using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.ViewModels.Accounts;

public class TopUpAccountViewModel
{
    public string? UseName { get; set; }
    
    [Display(Name = "Сумма")]
    public decimal Summ { get; set; }
    
    [Display(Name = "Номер счета")]
    [Remote("CheckExistCurrency", "TransactionsValidation", ErrorMessage = "Такой лицевой счет уже используется", AdditionalFields = "AccountNumber, UseName")]
    public string? AccountNumber { get; set; }
}