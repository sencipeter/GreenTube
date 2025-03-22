using Greentube.Wallet.Model.Commands;
using Greentube.Wallet.Model.Dto;

namespace Greentube.Wallet.Core.Handlers
{
    public interface ICreditTransactionHandler
    {
        TransactionResultDto? Handle(CreditTransactionCommand command);
    }
}
