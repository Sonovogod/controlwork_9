using controlWork_9.Services.TransactionsService.Abstract;
using controlWork_9.ViewModels.Accounts;
using controlWork_9.ViewModels.Providers;
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
            if (User.Identity.IsAuthenticated)
            {
                model.AccountNumber = User.Identity.Name;
            }
            bool result = await _transactionService.TopUpAccount(model);
            if (result)
            {
                return Ok("Счет пополнен");
            }
        }

        return BadRequest("Произошла ошибка при пополнеии счета");
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SendMoney(SendMoneyViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (User.Identity.Name.Equals(model.AccountNumber))
            {
                return BadRequest("Нельзя перевести на свой же текущий счет");
            }
            bool result = await _transactionService.SendMoney(model);
            if (result)
            {
                return Ok("Операция успешно проведена");
            }
        }

        return BadRequest("Произошла ошибка при переводе");
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult PayProviders()
    {
        PayProviderViewModel model = _transactionService.GetAllProviders();

        return View(model);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PayProviders(PayProviderViewModel model)
    {
        if (ModelState.IsValid)
        {
            bool result = await _transactionService.PayProvider(model, User.Identity.Name);
            if (result)
            {
                return Ok();
            }
        }

        return BadRequest();
    }
}