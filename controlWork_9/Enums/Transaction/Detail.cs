using System.ComponentModel;

namespace controlWork_9.Enums.Transaction;

public enum Detail
{
    [Description("Пополнение счета")]
    Reffil,
    [Description("Перевод")]
    Transfer,
    [Description("Оплата услуг")]
    Payment,
    
}