using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Data
{
    public class Market
    {
        public string Id { get; set; }
        public int SugarPrice { get; set; }
        public int FlourPrice { get; set; }
        public int EggsPrice { get; set; }
        public int ButterPrice { get; set; }
        public int ChocolatePrice { get; set; }
        public int MilkPrice { get; set; }

        private Random rand = new Random();

        public Market()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public void UpdateMarket()
        {
            this.SugarPrice = rand.Next(0, 200);
            this.FlourPrice = rand.Next(0, 300);
            this.EggsPrice = rand.Next(0, 600);
            this.ButterPrice = rand.Next(0, 400);
            this.ChocolatePrice = rand.Next(0, 900);
            this.MilkPrice = rand.Next(0, 50);
        }
    }
}
