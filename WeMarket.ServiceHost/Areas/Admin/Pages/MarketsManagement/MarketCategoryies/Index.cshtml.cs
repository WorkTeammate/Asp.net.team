using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _0_Framework.Infrastructure;
using ShopsManagement.Application.Contracts.Markets;
using ShopsManagement.Application.Contracts.Shops;
using ShopsManagement.Application.Contracts.MarketCategories;

namespace WeMarket.ServiceHost.Areas.Admin.Pages.MarketsManagement.MarketCategoryies
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public MarketCategorySearchModel SearchModel;
        public List<MarketCategoryViewModel> MarketCategories { get; set; }
        private readonly IMarketCategoryApplication _marketCategoryApplication;

        public IndexModel(IMarketCategoryApplication marketCategoryApplication)
        {
            _marketCategoryApplication = marketCategoryApplication;
        }

        public void OnGet(MarketCategorySearchModel searchModel)
        {
            MarketCategories = _marketCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateMarketCategory());
        }
        public IActionResult OnPostCreate(CreateMarketCategory command)
        {
            var result = _marketCategoryApplication.CreateMarketCategory(command);
            if (result.IsSuccessful)
            {
                return new JsonResult(result);
            }
            Message = result.Message;
            return Page();

        }

        public IActionResult OnGetEdit(long id)
        {
            var MarketCategoryies = _marketCategoryApplication.GetDetails(id);
            if(MarketCategoryies == null)
                return Page();
            return Partial("Edit", MarketCategoryies);
        }
        public IActionResult OnPostEdit(EditMarketCategory command)
        {
            var result = _marketCategoryApplication.EditMarketCategory(command);
            if (result.IsSuccessful)
            {
                return new JsonResult(result);
            }
            Message = result.Message;
            return Page();

        }

        public IActionResult OnGetRemove(long id)
        {
            var reault = _marketCategoryApplication.DeleteMarketCategory(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");


        }
        public IActionResult OnGetRestore(long id)
        {
          var reault =  _marketCategoryApplication.RestoreMarketCategory(id);
            if(!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");
        }
    }
}