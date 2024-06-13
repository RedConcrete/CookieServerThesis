using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Server.Data
{
    public class MarketPriceService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private int updateTime = 10;
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
            using (var scope = _serviceProvider.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<ServerContext>();

                List<Player> playerList = _db.Players.ToList();

                KVN kvn = new KVN();
                _db.KVN.Add(kvn);
                if (_db.Players.ToList().Count != 0)
                {
                    kvn.setNs(playerList);
                }
                else
                {
                    kvn.setNsTo10000();
                }
                kvn.setKVs();

                if (_db.Markets.ToList().Count == 0)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Market market = new Market();
                        market.SetKVN(kvn);
                        market.setRandomeMarketPrices();
                        _db.Markets.Add(market);
                    }
                }
                else
                {
                    List<Market> marketList = _db.Markets
                                .OrderByDescending(m => m.Date)
                                .Take(1)
                                .ToList();
                    var market = new Market();
                    market.SetKVN(kvn);
                    market.setMarketPrices(marketList[0]);

                    _db.Markets.Add(market);
                }
                await _db.SaveChangesAsync();
            }
        }
    }
}
