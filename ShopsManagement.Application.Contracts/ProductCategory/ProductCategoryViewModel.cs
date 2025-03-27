namespace ShopsManagement.Application.Contracts.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public string CreationDate { get; set; }
        public long ProductsCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
