using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopsManagement.Application.Contracts.Markets;
using ShopsManagement.Application.Contracts.Products;
using System.Collections.Generic;

namespace WeMarket.ServiceHost.Areas.Admin.Pages.Discounts.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public CustomerDiscountSearchModel SearchModel;
        public List<CustomerDiscountViewModel> CustomerDiscounts;
        public SelectList Products;
        public SelectList Markets;

        private readonly IProductApplication _productApplication;
        private readonly IMarketApplication _marketApplication;
        private readonly ICustomerDiscountApplication _customerDiscountApplication;

        public IndexModel(IProductApplication ProductApplication
            , ICustomerDiscountApplication customerDiscountApplication
            , IMarketApplication marketApplication)
        {
            _productApplication = ProductApplication;
            _customerDiscountApplication = customerDiscountApplication;
            _marketApplication = marketApplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            Markets = new SelectList(_marketApplication.GetMarkets(), "Id", "PersianName");
            CustomerDiscounts = _customerDiscountApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscount
            {
                Products = _productApplication.GetProducts(),
                Markets = _marketApplication.GetMarkets(),
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _customerDiscountApplication.DefineCustomerDiscount(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var customerDiscount = _customerDiscountApplication.GetDetails(id);
            customerDiscount.Products = _productApplication.GetProducts();
            customerDiscount.Markets= _marketApplication.GetMarkets();
            return Partial("Edit", customerDiscount);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.EditCustomerDiscount(command);
            return new JsonResult(result);
        }
    }
}
