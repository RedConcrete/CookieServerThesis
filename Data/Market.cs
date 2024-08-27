using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Data
{
    public class Market
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public float SugarPrice { get; set; }
        public float FlourPrice { get; set; }
        public float EggsPrice { get; set; }
        public float ButterPrice { get; set; }
        public float ChocolatePrice { get; set; }
        public float MilkPrice { get; set; }

        private KVN kvn;
        private int alpha = 5;
        private Random rand = new Random();
        private int constantPeriodThreshold = 5;
        private int constantPeriodCounter = 0;
        private float lastPrice = 0;

        public Market()
        {
            Id = Guid.NewGuid().ToString();
            Date = DateTime.UtcNow;
        }

        public void setMarketPrices(Market lastMarketItem)
        {
            float SugarKVNValue = alpha * ((float)kvn.SugarKV / kvn.SugarN);
            float FlourKVNValue = alpha * ((float)kvn.FlourKV / kvn.FlourN);
            float EggsKVNValue = alpha * ((float)kvn.EggsKV / kvn.EggsN);
            float ButterKVNValue = alpha * ((float)kvn.ButterKV / kvn.ButterN);
            float ChocolateKVNValue = alpha * ((float)kvn.ChocolateKV / kvn.ChocolateN);
            float MilkKVNValue = alpha * ((float)kvn.MilkKV / kvn.MilkN);

            SugarPrice = AdjustPrice(lastMarketItem.SugarPrice, SugarKVNValue);
            FlourPrice = AdjustPrice(lastMarketItem.FlourPrice, FlourKVNValue);
            EggsPrice = AdjustPrice(lastMarketItem.EggsPrice, EggsKVNValue);
            ButterPrice = AdjustPrice(lastMarketItem.ButterPrice, ButterKVNValue);
            ChocolatePrice = AdjustPrice(lastMarketItem.ChocolatePrice, ChocolateKVNValue);
            MilkPrice = AdjustPrice(lastMarketItem.MilkPrice, MilkKVNValue);
        }

        private float AdjustPrice(float lastPrice, float kvnValue)
        {
            float newPrice = Math.Min(1000, Math.Max(1, lastPrice + kvnValue));

            if (Math.Abs(newPrice - lastPrice) < 0.01f)
            {
                constantPeriodCounter++;
            }
            else
            {
                constantPeriodCounter = 0;
            }

            if (constantPeriodCounter >= constantPeriodThreshold)
            {
                constantPeriodCounter = 0;
                newPrice += rand.Next(-10, 10);
                newPrice = Math.Min(1000, Math.Max(1, newPrice));
            }

            return newPrice;
        }

        public void setRandomeMarketPrices()
        {
            SugarPrice = rand.Next(50, 100);
            FlourPrice = rand.Next(100, 200);
            EggsPrice = rand.Next(200, 300);
            ButterPrice = rand.Next(300, 400);
            ChocolatePrice = rand.Next(400, 500);
            MilkPrice = rand.Next(500, 600);
        }
        public void SetKVN(KVN kvn)
        {
            this.kvn = kvn;
        }
    }
}
