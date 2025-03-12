using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _0_Framework.Infrastructure;
using ShopsManagement.Application.Contracts.Markets;
using ShopsManagement.Application.Contracts.Shops;
using ShopsManagement.Application.Contracts.MarketCategories;

namespace WeMarket.ServiceHost.Areas.Admin.Pages.MarketsManagement.Markets
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public MarketSearchModel MarketSearchModel;
        public List<MarketViewModel> Markets { get; set; }
        public SelectList MarketCategories;
        private readonly IMarketCategoryApplication _marketCategoryApplication;
        private readonly IMarketApplication _marketApplication;

        public IndexModel(IMarketApplication marketApplication, IMarketCategoryApplication marketCategoryApplication)
        {
            _marketApplication = marketApplication;
            _marketCategoryApplication = marketCategoryApplication;
        }

        public void OnGet(MarketSearchModel searchModel)
        {
            MarketCategories = new SelectList(_marketCategoryApplication.GetMarketCategories(), "Id", "Name");
            Markets = _marketApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateMarkets
            {
                MarketCategories = _marketCategoryApplication.GetMarketCategories(),
                Longitude = 0,
                Latitude = 0,
            };
         
            return Partial("./Create", command);
        }
        public IActionResult OnPostCreate(CreateMarkets command)
        {
            var result = _marketApplication.CreateMarket(command);
            if (result.IsSuccessful)
            {
                return new JsonResult(result);
            }
            Message = result.Message;
            return Page();

        }

        public IActionResult OnGetEdit(long id)
        {
            var Markets = _marketApplication.GetDetails(id);
            if(Markets == null)
                return Page();
            Markets.MarketCategories = _marketCategoryApplication.GetMarketCategories();
            return Partial("Edit", Markets);
        }
        public IActionResult OnPostEdit(EditMarkets command)
        {
            var result = _marketApplication.EditMarket(command);
            if (result.IsSuccessful)
            {
                return new JsonResult(result);
            }
            Message = result.Message;
            return Page();

        }


        public IActionResult OnGetRemove(long id)
        {
            var reault = _marketApplication.RemovePage(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");


        }
        public IActionResult OnGetRestore(long id)
        {
            var reault = _marketApplication.RestorePage(id);
            if (!reault.IsSuccessful)
                Message = reault.Message;
            return RedirectToPage("./Index");
        }

    }
}