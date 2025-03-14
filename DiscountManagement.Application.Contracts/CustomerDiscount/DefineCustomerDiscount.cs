using _0_Framework.Application;
using ShopsManagement.Application.Contracts.Products;
using ShopsManagement.Application.Contracts.Shops;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long MarketId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string StartDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string EndDate { get; set; }

        public string Reason { get; set; }
        public int DiscountRate { get; set; }


        public List<ProductViewModel> Products { get; set; }
        public List<MarketViewModel> Markets { get; set; }
    }

}
