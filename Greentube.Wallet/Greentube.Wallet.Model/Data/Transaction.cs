namespace Greentube.Wallet.Model.Data
{
    public class Transaction
    {        
        public Guid Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public Guid PlayerId { get; set; }
        public Player? Player { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public enum TransactionType
    {
        Deposit, //(increments balance)
        Stake, //(decrements balance)
        Win //(increments balance)
    }
}
