using _0_Framework.Domain;
using BlogManagement.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : EntityBase
    {
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public int ShowOrder { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<Article> Articles { get; private set; }


        public ArticleCategory()
        {
            
        }

        public ArticleCategory(string name, string shortDescription, string picture, string pictureAlt
            , string pictureTitle, string slug, string keyWords, string metaDescription, string canonicalAddress, int showOrder)
        {
            Name = name;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            ShowOrder = showOrder;
            IsDeleted = false;
        }
        public void Edit(string name, string shortDescription, string picture, string pictureAlt
            , string pictureTitle, string slug, string keyWords, string metaDescription, string canonicalAddress, int showOrder)
        {
            Name = name;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            ShowOrder = showOrder;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
