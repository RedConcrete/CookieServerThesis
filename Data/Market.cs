using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Data
{
    public class Market
    {
        public string Id { get; set; }
        public DateTime Date{ get; set; }
        public int SugarPrice { get; set; }
        public int FlourPrice { get; set; }
        public int EggsPrice { get; set; }
        public int ButterPrice { get; set; }
        public int ChocolatePrice { get; set; }
        public int MilkPrice { get; set; }

        private Random rand = new Random();

        public Market()
        {
            setMarketPrices();
        }

        public void setMarketPrices()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Date = DateTime.UtcNow;

            this.SugarPrice = rand.Next(50, 100);
            this.FlourPrice = rand.Next(40, 90);
            this.EggsPrice = rand.Next(30, 80);
            this.ButterPrice = rand.Next(20, 70);
            this.ChocolatePrice = rand.Next(10, 60);
            this.MilkPrice = rand.Next(0, 50);
        }
    }
}
