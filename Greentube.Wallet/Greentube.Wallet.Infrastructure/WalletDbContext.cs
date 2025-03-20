using Greentube.Wallet.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace Greentube.Wallet.Infrastructure
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
