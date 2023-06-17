using controlWork_9.ViewModels.Accounts;
using controlWork_9.ViewModels.Providers;

namespace controlWork_9.Services.TransactionsService.Abstract;

public interface ITransactionService
{
    Task<bool> CheckSumm(decimal summ, string accountNumber);
    Task<bool> CheckCurrency(string accountNumber, string userName);
    Task<bool> TopUpAccount(TopUpAccountViewModel model);
    Task<bool> SendMoney(SendMoneyViewModel model);
    PayProviderViewModel GetAllProviders();
    Task<bool> PayProvider(PayProviderViewModel model, string userName);
}