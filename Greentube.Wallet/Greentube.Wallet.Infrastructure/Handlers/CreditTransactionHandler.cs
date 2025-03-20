using Greentube.Wallet.Core.Handlers;
using Greentube.Wallet.Core.Repositories;
using Greentube.Wallet.Model.Commands;
using Greentube.Wallet.Model.Data;
using Greentube.Wallet.Model.Dto;

namespace Greentube.Wallet.Infrastructure.Handlers
{
    public class CreditTransactionHandler : ICreditTransactionHandler
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITransactionRepository _transactionRepository;

        public CreditTransactionHandler(IPlayerRepository playerRepository, ITransactionRepository transactionRepository)
        {
            _playerRepository = playerRepository;
            _transactionRepository = transactionRepository;
        }

        public TransactionResultDto Handle(CreditTransactionCommand command)
        {
            if (_transactionRepository.TransactionExists(command.TransactionId))
            {
                return new TransactionResultDto { TransactionId = command.TransactionId, Accepted = true };
            }

            var player = _playerRepository.GetPlayer(command.PlayerId);
            var newBalance = player.Balance;

            switch (command.Type)
            {
                case TransactionType.Deposit:
                    newBalance += command.Amount;
                    break;
                case TransactionType.Stake:
                    newBalance -= command.Amount;
                    break;
                case TransactionType.Win:
                    newBalance += command.Amount;
                    break;
            }

            if (newBalance < 0)
            {
                return new TransactionResultDto { TransactionId = command.TransactionId, Accepted = false };
            }

            player.Balance = newBalance;
            var transaction = new Transaction
            {
                Id = command.TransactionId,
                PlayerId = command.PlayerId,
                TransactionType = command.Type,
                Amount = command.Amount,
                Timestamp = DateTime.UtcNow
            };

            _transactionRepository.AddTransaction(transaction);
            return new TransactionResultDto { TransactionId = command.TransactionId, Accepted = true };
        }
    }
}
