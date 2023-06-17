using controlWork_9.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace controlWork_9.Models;

public class WalletDbContext : IdentityDbContext<User>
{
    public DbSet<Provider> Providers { get; set; }
    public DbSet<AccountProvider> AccountProviders { get; set; }
    public DbSet<Tansaction> Transactions { get; set; }

    public WalletDbContext (DbContextOptions<WalletDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.SeedProviders();
    }
}