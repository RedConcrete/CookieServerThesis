using System.Diagnostics;
using System.Linq.Expressions;

namespace Server.Data
{
    public class KVN
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int SugarKV { get; set; }

        public int FlourKV { get; set; }

        public int EggsKV { get; set; }

        public int ButterKV { get; set; }

        public int ChocolateKV { get; set; }

        public int MilkKV { get; set; }
        private int SugarKVAdd { get; set; }

        private int FlourKVAdd { get; set; }

        private int EggsKVAdd { get; set; }

        private int ButterKVAdd { get; set; }

        private int ChocolateKVAdd { get; set; }

        private int MilkKVAdd { get; set; }
        public int SugarN { get; set; }
        public int FlourN { get; set; }
        public int EggsN { get; set; }
        public int ButterN { get; set; }
        public int ChocolateN { get; set; }
        public int MilkN { get; set; }

        private Random rand = new Random();

        public KVN()
        {
            Id = Guid.NewGuid().ToString();
            Date = DateTime.UtcNow;
        }

        public void addKVs(bool buy, string rec, int amount)
        {
            if (buy)
            {
                switch (rec)
                {
                    case "sugar":
                        SugarKVAdd += amount * SugarN / 10;
                        break;
                    case "flour":
                        FlourKVAdd += amount * FlourN / 10;
                        break;
                    case "eggs":
                        EggsKVAdd += amount * EggsN / 10;
                        break;
                    case "butter":
                        ButterKVAdd += amount * ButterN / 10;
                        break;
                    case "chocolate":
                        ChocolateKVAdd += amount * ChocolateN / 10;
                        break;
                    case "milk":
                        MilkKVAdd += amount * MilkN / 10;
                        break;
                    default:
                        Console.WriteLine(rec + " ist keine valide Recoucrese");
                        break;
                }
            }
            else
            {
                switch (rec)
                {
                    case "sugar":
                        SugarKVAdd -= amount * SugarN / 10;
                        break;
                    case "flour":
                        FlourKVAdd -= amount * FlourN / 10;
                        break;
                    case "eggs":
                        EggsKVAdd -= amount * EggsN / 10;
                        break;
                    case "butter":
                        ButterKVAdd -= amount * ButterN / 10;
                        break;
                    case "chocolate":
                        ChocolateKVAdd -= amount * ChocolateN / 10;
                        break;
                    case "milk":
                        MilkKVAdd -= amount * MilkN / 10;
                        break;
                    default:
                        Console.WriteLine(rec + " ist keine valide Recoucrese");
                        break;
                }
            }
        }

        public void setRandomKVs()
        {
            SugarKV = SugarKVAdd + rand.Next(-1000, 1000) * SugarN / 100;
            FlourKV = FlourKVAdd + rand.Next(-1000, 1000) * FlourN / 100;
            EggsKV = EggsKVAdd + rand.Next(-1000, 1000) * EggsN / 100;
            ButterKV = ButterKVAdd + rand.Next(-1000, 1000) * ButterN / 100;
            ChocolateKV = ChocolateKVAdd + rand.Next(-1000, 1000) * ChocolateN / 100;
            MilkKV = MilkKVAdd + rand.Next(-1000, 1000) * MilkN / 100;

            SugarKVAdd = 0; EggsKVAdd = 0; ButterKVAdd = 0; ChocolateKVAdd = 0; MilkKVAdd = 0; FlourKVAdd = 0;
        }
        public void setNs(List<Player> playerList)
        {
            SugarN = 0;
            FlourN = 0;
            EggsN = 0;
            ButterN = 0;
            ChocolateN = 0;
            MilkN = 0;

            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].Sugar <= 0) SugarN = SugarN + rand.Next(1000, 2000);
                else SugarN = SugarN + (int)playerList[i].Sugar;

                if (playerList[i].Flour <= 0) FlourN = FlourN + rand.Next(1000, 2000);
                else FlourN = FlourN + (int)playerList[i].Flour;

                if (playerList[i].Eggs <= 0) EggsN = EggsN + rand.Next(1000, 2000);
                else EggsN = EggsN + (int)playerList[i].Eggs;

                if (playerList[i].Butter <= 0) ButterN = ButterN + rand.Next(1000, 2000);
                else ButterN = ButterN + (int)playerList[i].Butter;

                if (playerList[i].Chocolate <= 0) ChocolateN = ChocolateN + rand.Next(1000, 2000);
                else ChocolateN = ChocolateN + (int)playerList[i].Chocolate;

                if (playerList[i].Milk <= 0) MilkN = MilkN + rand.Next(1000, 2000);
                else MilkN = MilkN + (int)playerList[i].Milk;
            }
        }
        public void setNsTo10000()
        {
            SugarN = 100000;
            FlourN = 100000;
            EggsN = 100000;
            ButterN = 100000;
            ChocolateN = 100000;
            MilkN = 100000;
        }
    }
}

