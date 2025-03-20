using Greentube.Wallet.Core.Repositories;
using Greentube.Wallet.Model.Data;

namespace Greentube.Wallet.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly WalletDbContext _context;

        public TransactionRepository(WalletDbContext context)
        {
            _context = context;
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public IList<Transaction> GetTransactions(Guid playerId) => _context.Transactions.Where(t => t.PlayerId == playerId).ToList();

        public bool TransactionExists(Guid transactionId) => _context.Transactions.Any(t => t.Id == transactionId);
    }
}
