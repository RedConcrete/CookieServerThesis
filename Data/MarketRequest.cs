namespace Server.Data
{
    public class MarketRequest
    {
        public string player { get; set; }
        public int amount { get; set; }
        public string rec { get; set; }

        public MarketRequest(string player, int amount, string rec)
        {
            this.player = player;
            this.amount = amount;
            this.rec = rec;
        }
    }
}
