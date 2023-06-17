using controlWork_9.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace controlWork_9.Extensions;

public static class DataSeed
{
    public static void SeedProviders(this ModelBuilder builder)
    {
        builder.Entity<Provider>()
            .HasData(new Provider()
            {
                Id = 1,
                Name = "Beeline"
            });
        
        builder.Entity<Provider>()
            .HasData(new Provider()
            {
                Id = 2,
                Name = "KazTransCom",
            });
    
        builder.Entity<AccountProvider>()
            .HasData(new AccountProvider()
            {
                Id = 1,
                Account = "7875463218",
                Balance = 0,
                ProviderId = 1
            });
        
        builder.Entity<AccountProvider>()
            .HasData(new AccountProvider()
            {
                Id = 2,
                Account = "7875883218",
                Balance = 0,
                ProviderId = 1
            });
        
        builder.Entity<AccountProvider>()
            .HasData(new AccountProvider()
            {
                Id = 3,
                Account = "7075463948",
                Balance = 0,
                ProviderId = 1
            });
        
        builder.Entity<AccountProvider>()
            .HasData(new AccountProvider()
            {
                Id = 4,
                Account = "318015460",
                Balance = 0,
                ProviderId = 2
            });
        
        builder.Entity<AccountProvider>()
            .HasData(new AccountProvider()
            {
                Id = 5,
                Account = "879647507",
                Balance = 0,
                ProviderId = 2
            });
        
        builder.Entity<AccountProvider>()
            .HasData(new AccountProvider()
            {
                Id = 6,
                Account = "390516300",
                Balance = 0,
                ProviderId = 2
            });
        
    }
    public static async Task SeedAdminUser(UserManager<User> userManager)
    {
        string adminUserName = "7476020287";
        string adminEmail = "admin@admin.com";
        string adminPassword = "12345";
        decimal balance = 100000;
        string adminAvatar = Path.Combine(@"\Logo", "primalLogo.png");

        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            User admin = new User
            {
                Email = adminEmail,
                UserName = adminUserName,
                Avatar = adminAvatar,
                DateOfCreate = DateTime.Now,
                Balance = balance
            };

            await userManager.CreateAsync(admin, adminPassword);
        }
    }
}