using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WeMarket.ServiceHost.Areas.Admin.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public ArticleSearchModel SearchModel;
        public List<ArticleViewModel> Articles;
        public SelectList ArticleCategories;

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");
            Articles = _articleApplication.Search(searchModel);
        }
        public IActionResult OnGetRemove(long id)
        {
            var reault = _articleApplication.Delete(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");


        }
        public IActionResult OnGetRestore(long id)
        {
            var reault = _articleApplication.Restore(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");
        }
    }
}
