namespace Cryptocurrency.DAL.DTOs
{
    public class TrendingCurrencyDto
    {
        public List<Coin> Coins { get; set; } = new List<Coin>();
    }

    public class Coin
    {
        public Item Item { get; set; } = null!;
    }

    public class Item
    {
        public string Id { get; set; } = null!;
        public int Coin_id { get; set; }
        public string Name { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string Small { get; set; } = null!;
        public int Score { get; set; }
    }
}
