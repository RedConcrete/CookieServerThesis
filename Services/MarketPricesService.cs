using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Timers;

namespace Server.Data
{
    public class MarketPriceService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private int updateTime = 1;

        public MarketPriceService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await UpdateMarketPrices();
                await Task.Delay(TimeSpan.FromSeconds(updateTime), stoppingToken);
            }
        }

        private async Task UpdateMarketPrices()
        {
            Console.WriteLine("----------------------------NEW PRICE-------------------------------");
            using (var scope = _serviceProvider.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<ServerContext>();
                var market = new Market();
                if (market == null)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        market = new Market();
                        market.UpdateMarket();
                        _db.Markets.Add(market);
                    }
                }

                _db.Markets.Add(market);
                market.UpdateMarket();
                await _db.SaveChangesAsync();
            }
            Console.WriteLine("----------------------------NEW PRICE-------------------------------");
        }
    }
}
