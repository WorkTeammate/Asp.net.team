using _0_Framework.Domain;
using _01_Framework.Application;
using ShopsManagement.Domain.ShopsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Domain.MarketCategoryAgg
{
    public class MarketCategory : EntityBase
    {
        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public bool IsDeleted { get; private set; }
        public string Slug { get; private set; }
        public List<Markets> Markets { get; private set; }

        protected MarketCategory()
        {
            
        }

        public MarketCategory(string name, string description, string picture, string pictureAlt, 
            string pictureTitle, string keyWords, string metaDescription, string slug )
        {
            Name = name;
            Description = description;
            if (picture == null)
                picture = "https://icon-library.com/images/category-icon-png/category-icon-png-2.jpg";
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            IsDeleted = false;
        }
        public void EditMarketCategory(string name, string description, string picture, string pictureAlt,
            string pictureTitle, string keyWords, string metaDescription, string slug )
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void DeleteMarketCategory() 
        {
            IsDeleted = true;
        }
        public void RestoreMarketCategory()
        {
            IsDeleted = false;
        }

    }
}
