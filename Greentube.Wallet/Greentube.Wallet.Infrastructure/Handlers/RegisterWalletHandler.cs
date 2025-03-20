using Greentube.Wallet.Core.Handlers;
using Greentube.Wallet.Core.Repositories;
using Greentube.Wallet.Model.Commands;
using Greentube.Wallet.Model.Data;

namespace Greentube.Wallet.Infrastructure.Handlers
{
    public class RegisterWalletHandler : IRegisterWalletHandler
    {
        private readonly IPlayerRepository _playerRepository;

        public RegisterWalletHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public bool Handle(RegisterWalletCommand command)
        {
            if (_playerRepository.PlayerExists(command.PlayerId))
            {
                return false;
            }

            var player = new Player { Id = command.PlayerId, Balance = 0 };
            _playerRepository.AddPlayer(player);
            return true;
        }
    }
}
