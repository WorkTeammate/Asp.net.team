namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }
        public string MeatDescription { get; set; }
        public string CanonicalAddress { get; set; }
        public int ShowOrder { get; set; }
        public bool IsDeleted { get; set; }
        public string CreationDate { get; set; }
    }
}
