using Greentube.Wallet.Model.Dto;
using Greentube.Wallet.Model.Queries;

namespace Greentube.Wallet.Core.Handlers
{
    public interface IGetPlayerBalanceHandler
    {
        PlayerBalanceDto Handle(GetPlayerBalanceQuery query);
    }
}
