using controlWork_9.Models;
using controlWork_9.Services.TransactionsService.Abstract;
using controlWork_9.Services.UsersServices.Abstracts;

namespace controlWork_9.Services.TransactionsService;

public class TransactionService : ITransactionService
{
    private readonly WalletDbContext _db;
    private readonly IUserService _userService;

    public TransactionService(WalletDbContext db, IUserService userService)
    {
        _db = db;
        _userService = userService;
    }

    public async Task<bool> CheckSumm(decimal summ, string accountNumber)
    {
        User? user = await _userService.FindByEmailOrLoginAsync(accountNumber);
        if (user is not null)
        {
            decimal remainder = user.Balance - summ;
            if (remainder >= 0)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<bool> CheckCurrency(string accountNumber, string userName)
    {
        if (!String.IsNullOrEmpty(userName))
        {
            return true;
        }

        return _db.Users.Any(x => x.UserName.Equals(accountNumber));
    }
}