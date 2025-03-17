using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }


        public string ShortDescription { get; set; }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(4000, ErrorMessage = ValidationMessages.MaxLength)]
        public string Picture { get; set; }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLength)]
        public string PictureAlt { get; set; }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLength)]
        public string PictureTitle { get; set; }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(70, ErrorMessage = ValidationMessages.MaxLength)]
        public string Slug { get; set; }



        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get; set; }

        public string MetaDescription { get; set; }


        public string CanonicalAddress { get; set; }


        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int ShowOrder { get; set; }


        public bool IsDeleted { get; set; }
    }
}
