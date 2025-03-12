using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application.Contracts.MarketCategories
{
    public class CreateMarketCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(4000)]
        public string Picture { get; set; }
        [MaxLength(200)]

        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MinLength(1)]
        [MaxLength(200)]
        public string KeyWords { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string MetaDescription { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }

    }
}
