using _01_Framework.Application;
using _01_Framework.Infrastructure;
using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopsManagement.Application.Contracts.ProductCategory;
using ShopsManagement.Application.Contracts.Products;
using ShopsManagement.Configuration.Permissions;

namespace WeMarket.ServiceHost.Areas.Admin.Pages.ProductsManagement.Products
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

        }

        public IActionResult OnGetCreate()
        {
            var account = _authHelper.CurrentAccountInfo();
            if (account == null)
                Message = ApplicationMessages.RecordNotFound;
            var command = new CreateProduct
            {
                Categories = _productCategoryApplication.GetProductCategories(),
                AccountId = account.Id
            };
            return Partial("./Create", command);
        }
        [NeedsPermission(ShopsPermissions.CreateProduct)]

        public IActionResult OnPostCreate(CreateProduct command)
        {
            var account = _authHelper.CurrentAccountInfo();
            if (account == null)
                Message = ApplicationMessages.RecordNotFound;

            command.AccountId = account.Id;

            var result = _productApplication.CreateProduct(command);
            if (result.IsSuccessful)
            {
                return new JsonResult(result);
            }
            Message = result.Message;
            return Page();

        }

        public IActionResult OnGetEdit(long id)
        {
            var Product = _productApplication.GetDetails(id);
            if(Product == null)
                return Page();

            Product.Categories = _productCategoryApplication.GetProductCategories();

            var account = _authHelper.CurrentAccountInfo();
            if (account == null)
                Message = ApplicationMessages.RecordNotFound;

            Product.AccountId = account.Id;
            return Partial("Edit", Product);
        }
        public IActionResult OnGetEditFileProduct(long id)
        {
            var Product = _productApplication.GetDetails(id);
            if (Product == null)
                return Page();
            var command = new EditFileProduct()
            {
                Id = Product.Id,
            };
            return Partial("EditFileProduct" , command);
        }
        public IActionResult OnPostEditFileProduct(EditFileProduct command) 
        {
            var result = _productApplication.EditFileProduct(command);
            if (result.IsSuccessful)
            {
                return new JsonResult(result);
            }
            Message = result.Message;
            return Page();
        }
        [NeedsPermission(ShopsPermissions.EditProduct)]

        public IActionResult OnPostEdit(EditProduct command)
        {
            var account = _authHelper.CurrentAccountInfo();
            if (account == null)
                Message = ApplicationMessages.RecordNotFound;

            command.AccountId = account.Id;
            var result = _productApplication.EditProduct(command);
            if (result.IsSuccessful)
            {
                return new JsonResult(result);
            }
            Message = result.Message;
            return Page();

        }


        public IActionResult OnGetRemove(long id)
        {
            var reault = _productApplication.Delete(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");


        }
        public IActionResult OnGetRestore(long id)
        {
            var reault = _productApplication.Restore(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");
        }
    }
}