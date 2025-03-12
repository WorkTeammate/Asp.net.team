using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application.Contracts.MarketCategories
{
    public interface IMarketCategoryApplication
    {
        OperationResult CreateMarketCategory(CreateMarketCategory command);
        OperationResult EditMarketCategory(EditMarketCategory command);
        EditMarketCategory GetDetails(long id);
        List<MarketCategoryViewModel> Search(MarketCategorySearchModel searchModel);
        List<MarketCategoryViewModel> GetMarketCategories();
        OperationResult DeleteMarketCategory(long id);
        OperationResult RestoreMarketCategory(long id);
    }
}
