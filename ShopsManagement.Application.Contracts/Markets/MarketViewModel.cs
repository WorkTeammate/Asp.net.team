namespace ShopsManagement.Application.Contracts.Shops
{
    public class MarketViewModel
    {
        public long Id { get; set; }
        public string PersianName { get; set; }
        public string EnglishName { get; set; }
        public string Description { get; set; }
        public string CreationDate { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public bool IsRemoved { get; set; }
        public string Slug { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long CategoryId { get; set; }
        public string MarketCategory { get; set; }
    }
}
