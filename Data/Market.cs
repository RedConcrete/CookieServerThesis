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
        private int alpha = 2;
        private Random rand = new Random();

        public Market()
        {
            Id = Guid.NewGuid().ToString();
            Date = DateTime.UtcNow;
        }

        public void setMarketPrices(Market lastMarketItem)
        {

            float SugarKVNValue = (alpha * (kvn.SugarKV / kvn.SugarN));
            float FlourKVNValue = (alpha * (kvn.FlourKV / kvn.FlourN));
            float EggsKVNValue = (alpha * (kvn.EggsKV / kvn.EggsN));
            float ButterKVNValue = (alpha * (kvn.ButterKV / kvn.ButterN));
            float ChocolateKVNValue = (alpha * (kvn.ChocolateKV / kvn.ChocolateN));
            float MilkKVNValue = (alpha * (kvn.MilkKV / kvn.MilkN));

            

            SugarPrice = lastMarketItem.SugarPrice + SugarKVNValue;
            FlourPrice = lastMarketItem.FlourPrice + FlourKVNValue;
            EggsPrice = lastMarketItem.EggsPrice + EggsKVNValue;
            ButterPrice = lastMarketItem.ButterPrice + ButterKVNValue;
            ChocolatePrice = lastMarketItem.ChocolatePrice + ChocolateKVNValue;
            MilkPrice = lastMarketItem.MilkPrice + MilkKVNValue;

            Console.WriteLine("------------------------------------------------------------------------------------------------------- " + SugarKVNValue.ToString());
            Console.WriteLine("------------------------------------------------------------------------------------------------------- " + SugarPrice.ToString());
            Console.WriteLine("------------------------------------------------------------------------------------------------------- " + lastMarketItem.SugarPrice.ToString());
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
