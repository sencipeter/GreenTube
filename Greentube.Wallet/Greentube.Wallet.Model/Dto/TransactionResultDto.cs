namespace Greentube.Wallet.Model.Dto
{
    public class TransactionResultDto
    {
        public Guid TransactionId { get; set; }
        public bool Accepted { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
