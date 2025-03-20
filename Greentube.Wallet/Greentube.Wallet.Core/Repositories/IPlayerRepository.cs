using Greentube.Wallet.Model.Data;

namespace Greentube.Wallet.Core.Repositories
{
    public interface IPlayerRepository
    {
        Player GetPlayer(Guid playerId);
        void AddPlayer(Player player);
        bool PlayerExists(Guid playerId);
    }
}
