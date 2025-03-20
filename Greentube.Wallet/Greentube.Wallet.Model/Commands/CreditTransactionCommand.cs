using Greentube.Wallet.Model.Data;

namespace Greentube.Wallet.Model.Commands
{
    public class CreditTransactionCommand
    {
        public Guid PlayerId { get; set; }
        public Guid TransactionId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
    }
}
