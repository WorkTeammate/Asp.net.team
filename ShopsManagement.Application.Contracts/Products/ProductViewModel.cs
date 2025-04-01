namespace ShopsManagement.Application.Contracts.Products
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string Category { get; set; }
        public string CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public string ProductCategory { get; set; }
        public long CategoryId { get; set; }
        public long AccountId { get; set; }
        public string Accounts { get; set; }

    }
}
