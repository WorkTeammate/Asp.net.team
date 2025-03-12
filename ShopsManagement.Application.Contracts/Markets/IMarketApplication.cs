using _0_Framework.Application;
using ShopsManagement.Application.Contracts.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application.Contracts.Markets
{
    public interface IMarketApplication
    {
        OperationResult CreateMarket(CreateMarkets command);
        OperationResult EditMarket(EditMarkets command);
        EditMarkets GetDetails(long id);
        List<MarketViewModel> Search(MarketSearchModel searchModel);
        List<MarketViewModel> GetMarkets();
        OperationResult RemovePage(long id);
        OperationResult RestorePage(long id);
    }
}
