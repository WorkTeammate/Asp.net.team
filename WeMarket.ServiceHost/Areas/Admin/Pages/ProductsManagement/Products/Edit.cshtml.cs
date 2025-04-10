using _01_Framework.Application;
using BlogManagement.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopsManagement.Application.Contracts.ProductCategory;
using ShopsManagement.Application.Contracts.Products;

namespace WeMarket.ServiceHost.Areas.Admin.Pages.ProductsManagement.Products
{
    public class Edit : PageModel
    {
        string Message;
        public EditProduct Command;
        public SelectList Category;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly IAuthHelper _authHelper;

        public Edit(IAuthHelper authHelper
            , IProductCategoryApplication productCategoryApplication
            , IProductApplication productApplication)
        {
            _authHelper = authHelper;
            _productCategoryApplication = productCategoryApplication;
            _productApplication = productApplication;
        }

        public void OnGet(long Id)
        {
            Command = _productApplication.GetDetails(Id);
            Category = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
        }

        public IActionResult OnPost(EditProduct command , long id)
        {
            var account = _authHelper.CurrentAccountInfo();
            if (account == null)
                Message = ApplicationMessages.RecordNotFound;

            command.Id = id;
            var slug = command.Name;
            slug.Slugify();
            command.Slug= slug;
            command.AccountId = account.Id;

            var result = _productApplication.EditProduct(command);
            return RedirectToPage("./Index");
        }
    }
}
