namespace Server.Data
{
    public class KVN
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int SugarKV { get; set; }
        public int SugarN { get; set; }
        public int FlourKV { get; set; }
        public int FlourN { get; set; }
        public int EggsKV { get; set; }
        public int EggsN { get; set; }
        public int ButterKV { get; set; }
        public int ButterN { get; set; }
        public int ChocolateKV { get; set; }
        public int ChocolateN { get; set; }
        public int MilkKV { get; set; }
        public int MilkN { get; set; }

        private Random rand = new Random();

        public KVN()
        {
            Id = Guid.NewGuid().ToString();
            Date = DateTime.UtcNow;
        }

        public void setKVs()
        {
            SugarKV = rand.Next(-100, 100) * 100;
            FlourKV = rand.Next(-200, 100) * 100;
            EggsKV = rand.Next(-100, 150) * 100;
            ButterKV = rand.Next(-150, 100) * 100;
            ChocolateKV = rand.Next(-200, 200) * 100;
            MilkKV = rand.Next(-300, 300) * 100;
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
                if (playerList[i].Sugar <= 0) SugarN = SugarN + rand.Next(10, 100);
                else SugarN = SugarN + (int)playerList[i].Sugar;

                if (playerList[i].Flour <= 0) FlourN = FlourN + rand.Next(10, 100);
                else FlourN = FlourN + (int)playerList[i].Flour;

                if (playerList[i].Eggs <= 0) EggsN = EggsN + rand.Next(10, 100);
                else EggsN = EggsN + (int)playerList[i].Eggs;

                if (playerList[i].Butter <= 0) ButterN = ButterN + rand.Next(10, 100);
                else ButterN = ButterN + (int)playerList[i].Butter;

                if (playerList[i].Chocolate <= 0) ChocolateN = ChocolateN + rand.Next(10, 100);
                else ChocolateN = ChocolateN + (int)playerList[i].Chocolate;

                if (playerList[i].Milk <= 0) MilkN = MilkN + rand.Next(10, 100);
                else MilkN = MilkN + (int)playerList[i].Milk;
            }
        }
        public void setNsTo10000()
        {
            SugarN = 10000;
            FlourN = 10000;
            EggsN = 10000;
            ButterN = 10000;
            ChocolateN = 10000;
            MilkN = 10000;
        }
    }
}

