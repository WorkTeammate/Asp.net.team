using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogManagement.Application.Contracts.ArticleCategory;

namespace WeMarket.ServiceHost.Areas.Admin.Pages.Blog.ArticleCategory
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public ArticleCategorySearchModel SearchModel;
        public List<ArticleCategoryViewModel> ArticleCategory { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            ArticleCategory = _articleCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateArticleCategory());
        }
        public IActionResult OnPostCreate(CreateArticleCategory command)
        {
            var result = _articleCategoryApplication.Create(command);
            if (result.IsSuccessful)
            {
                return new JsonResult(result);
            }
            Message = result.Message;
            return Page();

        }

        public IActionResult OnGetEdit(long id)
        {
            var ArtileCategoryies = _articleCategoryApplication.GetDetails(id);
            if(ArtileCategoryies == null)
                return Page();
            return Partial("Edit", ArtileCategoryies);
        }
        public IActionResult OnPostEdit(EditArticleCategory command)
        {
            var result = _articleCategoryApplication.Edit(command);
            if (result.IsSuccessful)
            {
                return new JsonResult(result);
            }
            Message = result.Message;
            return Page();

        }

        public IActionResult OnGetRemove(long id)
        {
            var reault = _articleCategoryApplication.Delete(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");


        }
        public IActionResult OnGetRestore(long id)
        {
          var reault =  _articleCategoryApplication.Restore(id);
            if(!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");
        }
    }
}