using _01_Framework.Domain;
using Market.ShopsManagement.Domain.ProductsAgg;
using ShopsManagement.Domain.ProductsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<Products> Products { get; private set; }

        public ProductCategory()
        {
            Products = new List<Products>();
        }

        public ProductCategory(string name, string shortDescription, string picture
            , string pictureAlt, string pictureTitle, string keyWords, string metaDescription, string slug)
        {
            Name = name;
            ShortDescription = shortDescription;
            if (string.IsNullOrWhiteSpace(picture))
                picture = "https://images.icon-icons.com/2483/PNG/512/document_category_icon_149943.png";
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
            IsDeleted = false;
        }
        public void Edit(string name, string shortDescription, string picture
            , string pictureAlt, string pictureTitle, string keyWords, string metaDescription, string slug)
        {
            Name = name;
            ShortDescription = shortDescription;
            if (string.IsNullOrWhiteSpace(picture))
                picture = "https://images.icon-icons.com/2483/PNG/512/document_category_icon_149943.png";
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;
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
