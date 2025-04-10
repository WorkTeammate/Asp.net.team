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

        }

        public IActionResult OnGetPublish(long id)
        {
            var reault = _productApplication.Published(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetDownload(string FileProduct)
        {
            
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "AdminTheme", "UploadPicture", FileProduct);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // اگر فایل وجود نداشته باشد
            }
            var contentType = "application/octet-stream"; // نوع محتوا برای دانلود
            return File(System.IO.File.ReadAllBytes(filePath), contentType, FileProduct);
        }
        public IActionResult OnGetReject(long id)
        {
            var reault = _productApplication.RejectProduct(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetDetails(long id)
        {
            var Product = _productApplication.GetDetails(id);
            if (Product == null)
                return Page();


            var account = _authHelper.CurrentAccountInfo();
            if (account == null)
                Message = ApplicationMessages.RecordNotFound;

            Product.AccountId = account.Id;
            return Partial("Details", Product);
        }
    }
}