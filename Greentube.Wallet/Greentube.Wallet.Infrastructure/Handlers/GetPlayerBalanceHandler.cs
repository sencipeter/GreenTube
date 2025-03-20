using Greentube.Wallet.Core.Handlers;
using Greentube.Wallet.Core.Repositories;
using Greentube.Wallet.Model.Dto;
using Greentube.Wallet.Model.Queries;

namespace Greentube.Wallet.Infrastructure.Handlers
{
    public class GetPlayerBalanceHandler : IGetPlayerBalanceHandler
    {
        private readonly IPlayerRepository _playerRepository;

        public GetPlayerBalanceHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public PlayerBalanceDto Handle(GetPlayerBalanceQuery query)
        {
            var player = _playerRepository.GetPlayer(query.PlayerId);
            return new PlayerBalanceDto { PlayerId = player.Id, Balance = player.Balance };
        }
    }
}
