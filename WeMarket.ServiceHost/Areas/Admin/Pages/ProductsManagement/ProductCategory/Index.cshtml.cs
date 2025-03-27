using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopsManagement.Application.Contracts.ProductCategory;

namespace WeMarket.ServiceHost.Areas.Admin.Pages.ProductsManagement.ProductCategory
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public ProductCategorySearchModel SearchModel;
        public List<ProductCategoryViewModel> ProductCategories;

        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }


        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }
        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productCategoryApplication.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var reault = _productCategoryApplication.Delete(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");


        }
        public IActionResult OnGetRestore(long id)
        {
            var reault = _productCategoryApplication.Restore(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");
        }
    }
}