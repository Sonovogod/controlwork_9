using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.ViewModels.Providers;

public class PayProviderViewModel
{
    public List<ProviderViewModel>? Providers { get; set; }
    
    [Display(Name = "Сумма")]
    [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Только положительные числа")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    [Remote("CheckExistMoney", "TransactionsValidation", ErrorMessage = "Недостаточно средств", AdditionalFields = "Summ")]
    public decimal Summ { get; set; }
    
    [Display(Name = "Поставщик услуг")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public int ProviderId { get; set; }
    
    [Display(Name = "Номер лицевого счета")]
    [Required(ErrorMessage = "Поле не может быть пустым")]
    public int AccountProviderId { get; set; }
}