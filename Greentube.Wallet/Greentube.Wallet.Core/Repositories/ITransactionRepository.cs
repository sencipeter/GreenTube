using Greentube.Wallet.Model.Data;

namespace Greentube.Wallet.Core.Repositories
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        IList<Transaction> GetTransactions(Guid playerId);
        bool TransactionExists(Guid transactionId);
    }
}
