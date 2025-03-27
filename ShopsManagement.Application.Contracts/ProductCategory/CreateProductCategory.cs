using _01_Framework.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }

        //[Required(ErrorMessage = ValidationMessages.IsRequired)]
        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
    }
}
