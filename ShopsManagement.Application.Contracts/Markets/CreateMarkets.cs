using _0_Framework.Application;
using _01_Framework.Application;
using ShopsManagement.Application.Contracts.MarketCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopsManagement.Application.Contracts.Shops
{
    public class CreateMarkets
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100)]
        public string PersianName { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100)]
        public string EnglishName { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(200, ErrorMessage = ValidationMessages.MaxLength)]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(4000, ErrorMessage = ValidationMessages.MaxLength)]
        public string Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLength)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(150, ErrorMessage = ValidationMessages.MaxLength)]
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLength)]
        public string Slug { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }

        public List<MarketCategoryViewModel> MarketCategories { get; set; }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLength)]
        public string KeyWords { get; set; }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLength)]
        public string MetaDescription { get; set; }


        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long TownId { get; set; }

        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long CityId { get; set; }


    }
}
