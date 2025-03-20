using Greentube.Wallet.Model.Commands;

namespace Greentube.Wallet.Core.Handlers
{
    public interface IRegisterWalletHandler
    {
        bool Handle(RegisterWalletCommand command);
    }
}
