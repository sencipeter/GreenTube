using Greentube.Wallet.Core.Handlers;
using Greentube.Wallet.Core.Repositories;
using Greentube.Wallet.Model.Data;
using Greentube.Wallet.Model.Queries;

namespace Greentube.Wallet.Infrastructure.Handlers
{
    public class GetPlayerTransactionsHandler : IGetPlayerTransactionsHandler
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetPlayerTransactionsHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IList<Transaction> Handle(GetPlayerTransactionsQuery query)
        {
            return _transactionRepository.GetTransactions(query.PlayerId);
        }
    }
}
