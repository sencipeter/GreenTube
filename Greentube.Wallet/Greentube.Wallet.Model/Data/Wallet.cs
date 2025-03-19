namespace Greentube.Wallet.Model.Data
{
    public class Wallet
    {
        public Player Player { get; set; }
        public List<Transaction> Transactions { get; set; } =new List<Transaction>();

        public Wallet(Player player) 
        {
            Player = player;
        }
    }
}
