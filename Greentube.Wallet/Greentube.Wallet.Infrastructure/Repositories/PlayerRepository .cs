using Greentube.Wallet.Core.Repositories;
using Greentube.Wallet.Model.Data;


namespace Greentube.Wallet.Infrastructure.Repositories
{
    public class PlayerRepository: IPlayerRepository
    {
        private readonly WalletDbContext _context;

        public PlayerRepository(WalletDbContext context)
        {
            _context = context;
        }

        public Player GetPlayer(Guid playerId) => _context.Players.Find(playerId);

        public void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public bool PlayerExists(Guid playerId) => _context.Players.Any(p => p.Id == playerId);
    }
}
