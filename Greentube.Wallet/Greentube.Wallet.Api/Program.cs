
using Greentube.Wallet.Core.Handlers;
using Greentube.Wallet.Core.Repositories;
using Greentube.Wallet.Infrastructure;
using Greentube.Wallet.Infrastructure.Handlers;
using Greentube.Wallet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Greentube.Wallet.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<WalletDbContext>(options => options.UseInMemoryDatabase("WalletDb"));
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<IGetPlayerBalanceHandler, GetPlayerBalanceHandler>();
            builder.Services.AddScoped<IGetPlayerTransactionsHandler, GetPlayerTransactionsHandler>();
            builder.Services.AddScoped<IRegisterWalletHandler, RegisterWalletHandler>();
            builder.Services.AddScoped<ICreditTransactionHandler, CreditTransactionHandler>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
