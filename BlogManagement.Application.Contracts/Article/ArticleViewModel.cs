using BlogManagement.Application.Contracts.ArticleCategory;

namespace BlogManagement.Application.Contracts.Article
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string PublishDate { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
        public long CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string CreationDate { get; set; }
        public string Category { get; set; }
    }
}
