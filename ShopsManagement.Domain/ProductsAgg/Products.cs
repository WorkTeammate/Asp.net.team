using _01_Framework.Domain;
using AccountManagement.Domain.AccountAgg;
using Market.AccountManagement.Domain.AccountAgg;
using ShopsManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ShopsManagement.Domain.ProductsAgg
{
    public class Products : EntityBase
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
        public ProductCategory Category { get; private set; }
        public long CategoryId { get;private set; }
        public long AccountId { get; private set; }
        public string FileProducts { get; private set; }
        protected Products()
        {
            
        }
        public Products(string name, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string slug
            , string keywords, string metaDescription, long categoryid , long accountId , string fileproduct)
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
            CategoryId = categoryid;
            IsDeleted = false;
            AccountId = accountId;
            FileProducts = fileproduct;
        }
        public void Edit(string name, string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string slug
            , string keywords, string metaDescription, long categoryid , long accountId)
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
            CategoryId = categoryid;
            AccountId= accountId;
        }

        public void Remove()
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted = false;
        }
        public void EditFileProduct(string fileProduct)
        {
            FileProducts = fileProduct;
        }
    }
}
