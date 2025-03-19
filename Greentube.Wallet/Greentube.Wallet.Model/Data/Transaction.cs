namespace Greentube.Wallet.Model.Data
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
    }

    public enum TransactionType
    {
        Deposit, //(increments balance)
        Stake, //(decrements balance)
        Win //(increments balance)
    }
}
