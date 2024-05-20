namespace Server.Data
{
    public class Player
    {
        public string Id { get; set; }
        public int Cookies { get; set; }
        public int Sugar { get; set; }
        public int Flour { get; set; }
        public int Eggs { get; set; }
        public int Butter { get; set; }
        public int Chocolate { get; set; }
        public int Milk { get; set; }


        public Player()
        {

        }

        public void UpdatePlayer(Player player)
        {
            this.Cookies = player.Cookies;
            this.Sugar = player.Sugar;
            this.Flour = player.Flour;
            this.Eggs = player.Eggs;
            this.Butter = player.Butter;
            this.Chocolate = player.Chocolate;
            this.Milk = player.Milk;
        }
    }
}
