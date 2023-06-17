using controlWork_9.Models;
using controlWork_9.Services.TransactionsService.Abstract;
using controlWork_9.Services.UsersServices.Abstracts;
using controlWork_9.ViewModels.Accounts;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> TopUpAccount(TopUpAccountViewModel model)
    {
        try
        {
            User user = await _db.Users.FirstOrDefaultAsync(x=> x.UserName.Equals(model.AccountNumber));
            user.Balance += model.Summ;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> SendMoney(SendMoneyViewModel model)
    {
        try
        {
            User sender = await _db.Users.FirstOrDefaultAsync(x=> x.UserName.Equals(model.UserName));
            User receiver = await _db.Users.FirstOrDefaultAsync(x=> x.UserName.Equals(model.AccountNumber));
            
            sender.Balance -= model.Summ;
            receiver.Balance += model.Summ;
            _db.Users.Update(sender);
            _db.Users.Update(receiver);
            await _db.SaveChangesAsync();
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }
}