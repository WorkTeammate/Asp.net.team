using _0_Framework.Domain;
using _01_Framework.Application;
using CountryData.Standard;
using InventoryManagement.Application.Contracts.Inventory;
using ShopsManagement.Domain.MarketCategoryAgg;
using ShopsManagement.Domain.ProductAgg;

namespace ShopsManagement.Domain.ShopsAgg
{
    public class Markets : EntityBase
    {
        public string PersianName { get; private set; }
        public string EnglishName { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public bool IsRemoved { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public long CategoryId { get; private set; }
        public MarketCategory MarketCategory { get; private set; }
        public string KewWords { get; private set; }

        public List<Product> Products { get; private set; }

        public string MetaDescription { get; private set; }





        //Product 

        protected Markets()
        {

        }

        public Markets(string persianName, string englishName, string description, string shortDescription,
            string picture, string pictureAlt, string pictureTitle, string slug
            , Double latitude, Double longitude, long categoryId, string kewWords, string metaDescription)
        {



            PersianName = persianName;

            EnglishName = englishName;
            Description = description;

            ShortDescription = shortDescription;
            if (picture == null)
                picture = "https://www.creativefabrica.com/wp-content/uploads/2019/02/Online-shop-shopping-shop-logo-by-DEEMKA-STUDIO-1.jpg";
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Latitude = latitude;
            Longitude = longitude;
            IsRemoved = false;
            CategoryId = categoryId;
            KewWords = kewWords;
            MetaDescription = metaDescription;

        }


        public void Edit(string persianName, string englishName, string description, string shortDescription,
            string picture, string pictureAlt, string pictureTitle, string slug,  Double latitude, Double longitude
            , long categoryId, string kewWords, string metaDescription)
        {
            PersianName = persianName;
            EnglishName = englishName;
            Description = description;

            ShortDescription = shortDescription;
            if (picture == null)
                picture = "https://www.creativefabrica.com/wp-content/uploads/2019/02/Online-shop-shopping-shop-logo-by-DEEMKA-STUDIO-1.jpg";
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Latitude = latitude;
            Longitude = longitude;
            CategoryId = categoryId;
            KewWords = kewWords;
            MetaDescription = metaDescription;
        }

        public void RemovePage()
        {
            IsRemoved = true;
        }
        public void RestorePage()
        {
            IsRemoved = false;
        }



    }


}
