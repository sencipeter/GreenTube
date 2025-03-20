using Greentube.Wallet.Core.Handlers;
using Greentube.Wallet.Model.Commands;
using Greentube.Wallet.Model.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Greentube.Wallet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IGetPlayerBalanceHandler _getPlayerBalanceHandler;
        private readonly IGetPlayerTransactionsHandler _getPlayerTransactionsHandler;
        private readonly IRegisterWalletHandler _registerWalletHandler;
        private readonly ICreditTransactionHandler _creditTransactionHandler;

        public WalletController(
            IGetPlayerBalanceHandler getPlayerBalanceHandler,
            IGetPlayerTransactionsHandler getPlayerTransactionsHandler,
            IRegisterWalletHandler registerWalletHandler,
            ICreditTransactionHandler creditTransactionHandler)
        {
            _getPlayerBalanceHandler = getPlayerBalanceHandler;
            _getPlayerTransactionsHandler = getPlayerTransactionsHandler;
            _registerWalletHandler = registerWalletHandler;
            _creditTransactionHandler = creditTransactionHandler;
        }

        [HttpPost("register")]
        public IActionResult RegisterWallet([FromBody] RegisterWalletCommand command)
        {
            var result = _registerWalletHandler.Handle(command);
            if (!result)
            {
                return BadRequest("Player's wallet is already registered.");
            }
            return Ok();
        }

        [HttpGet("{playerId}/balance")]
        public IActionResult GetBalance(Guid playerId)
        {
            var query = new GetPlayerBalanceQuery { PlayerId = playerId };
            var balance = _getPlayerBalanceHandler.Handle(query);
            if (balance is null)
                return NotFound();
            return Ok(balance);
        }

        [HttpPost("transaction")]
        public IActionResult CreditTransaction([FromBody] CreditTransactionCommand command)
        {
            var result = _creditTransactionHandler.Handle(command);
            return Ok(result);
        }

        [HttpGet("{playerId}/transactions")]
        public IActionResult GetTransactions(Guid playerId)
        {
            var query = new GetPlayerTransactionsQuery { PlayerId = playerId };
            var transactions = _getPlayerTransactionsHandler.Handle(query);
            return Ok(transactions);
        }
    }
}
