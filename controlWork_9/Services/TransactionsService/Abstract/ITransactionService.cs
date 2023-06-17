namespace controlWork_9.Services.TransactionsService.Abstract;

public interface ITransactionService
{
    Task<bool> CheckSumm(decimal summ, string accountNumber);
    Task<bool> CheckCurrency(string accountNumber, string userName);
}