using _0_Framework.Domain;
using ShopsManagement.Domain.ShopsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public bool IsDeleted { get; private set; }
        public Markets Markets { get; private set; }
        public long MarketId { get; private set; }

        protected Product()
        {
            
        }

        public Product(string name, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string slug, string keywords, string metaDescription , long marketid)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            IsDeleted = false;
            MarketId = marketid;
        }
        public void Edit(string name, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string slug, string keywords, string metaDescription , long marketid)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            MarketId = marketid;

        }

        public void Remove()
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
