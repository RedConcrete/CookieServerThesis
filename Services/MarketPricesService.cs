using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Server.Data
{
    public class MarketPriceService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private int updateTime = 60;
        private Timer _timer;

        public MarketPriceService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(UpdateMarketPrices, null, TimeSpan.Zero, TimeSpan.FromSeconds(updateTime));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void UpdateMarketPrices(object state)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(dateTime + ": ----------------------------NEW PRICE-------------------------------");
            using (var scope = _serviceProvider.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<ServerContext>();
                var market = new Market();
                if (_db.Markets.ToList().Count == 0)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        market = new Market();
                        market.UpdateMarket();
                        _db.Markets.Add(market);
                    }
                }
                market.UpdateMarket();
                _db.Markets.Add(market);
                await _db.SaveChangesAsync();
            }
        }
    }
}
