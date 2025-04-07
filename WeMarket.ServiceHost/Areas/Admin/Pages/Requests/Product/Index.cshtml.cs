using _01_Framework.Application;
using _01_Framework.Infrastructure;
using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopsManagement.Application.Contracts.ProductCategory;
using ShopsManagement.Application.Contracts.Products;
using ShopsManagement.Configuration.Permissions;

namespace WeMarket.ServiceHost.Areas.Admin.Pages.Requests.Product
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Product { get; set; }
        public SelectList ProductCategories;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly IAuthHelper _authHelper;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication, IAuthHelper authHelper)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
            _authHelper = authHelper;
        }
        [NeedsPermission(ShopsPermissions.ListProduct)]

        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Product = _productApplication.Search(searchModel);
            Product.Where(x => x.IsPublished == false);

        }

        public IActionResult OnGetPublish(long id)
        {
            var reault = _productApplication.Published(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");
        }
    }
}