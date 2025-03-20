using Greentube.Wallet.Model.Data;
using Greentube.Wallet.Model.Queries;

namespace Greentube.Wallet.Core.Handlers
{
    public interface IGetPlayerTransactionsHandler
    {
        IList<Transaction> Handle(GetPlayerTransactionsQuery query);
    }
}
