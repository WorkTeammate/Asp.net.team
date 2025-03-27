using _01_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        public string ShortDescription { get; set; }


        public string Description { get; set; }



        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(4000, ErrorMessage = ValidationMessages.MaxLength)]
        public string Picture { get; set; }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]

        public string PictureAlt { get; set; }

        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }

        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        public string PublishDate { get; set; }

        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
