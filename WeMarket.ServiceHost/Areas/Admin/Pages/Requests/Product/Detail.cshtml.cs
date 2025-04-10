using _01_Framework.Application;
using BlogManagement.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopsManagement.Application.Contracts.ProductCategory;
using ShopsManagement.Application.Contracts.Products;

namespace WeMarket.ServiceHost.Areas.Admin.Pages.Requests.Product
{
    public class DetailModel : PageModel
    {
        string Message;
        public EditProduct Command;

        private readonly IProductApplication _productApplication;
        private readonly IAuthHelper _authHelper;

        public DetailModel(IAuthHelper authHelper
            , IProductCategoryApplication productCategoryApplication
            , IProductApplication productApplication)
        {
            _authHelper = authHelper;
            _productApplication = productApplication;
        }

        public void OnGet(long id)
        {
            Command = _productApplication.GetDetails(id);
        }

    }
}
