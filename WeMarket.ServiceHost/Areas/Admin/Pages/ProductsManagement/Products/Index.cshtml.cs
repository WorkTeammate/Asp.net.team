using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _0_Framework.Infrastructure;
using ShopsManagement.Application.Contracts.Products;

namespace WeMarket.ServiceHost.Areas.Admin.Pages.ProductsManagement.Products
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Product { get; set; }
        public SelectList Markets;

        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            Product = _productApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
             
            };
            return Partial("./Create", command);
        }
        public IActionResult OnPostCreate(CreateProduct command)
        {
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
            return Partial("Edit", Product);
        }
        public IActionResult OnPostEdit(EditProduct command)
        {
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