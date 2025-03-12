namespace ShopsManagement.Application.Contracts.Shops
{
    public class MarketSearchModel
    {
        public string PersianName { get; set; }
        public string EnglishName { get; set; }
        public string ShortDescription { get; set; }
        public long CategoryId { get; set; }

        public bool IsRemoved { get; set; }
    }
}
