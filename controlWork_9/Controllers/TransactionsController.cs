using controlWork_9.Services.TransactionsService.Abstract;
using controlWork_9.ViewModels.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace controlWork_9.Controllers;

public class TransactionsController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> TopUpAccount(TopUpAccountViewModel model)
    {
        if (ModelState.IsValid)
        {
            bool result = await _transactionService.TopUpAccount(model);
            if (result)
            {
                return Ok("Счет пополнен");
            }
        }

        return BadRequest("Произошла ошибка при пополнеии счета");
    }
}