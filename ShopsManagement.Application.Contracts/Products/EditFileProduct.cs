using _01_Framework.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application.Contracts.Products
{
    public class EditFileProduct
    {
        public long Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" , "Pdf" , "txt"}, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile FileProduct { get; set; }
    }
}
