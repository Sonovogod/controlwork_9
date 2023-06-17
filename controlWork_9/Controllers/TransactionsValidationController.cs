using controlWork_9.Services.TransactionsService.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.Controllers;

public class TransactionsValidationController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionsValidationController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [AcceptVerbs("GET", "POST")]
    public async Task<bool> CheckExisMoney(decimal summ, string userName)
        => await _transactionService.CheckSumm(summ, userName);
    
    [AcceptVerbs("GET", "POST")]
    public async Task<bool> CheckExistCurrency(string accountNumber, string userName)
        => await _transactionService.CheckCurrency(accountNumber, userName);
}