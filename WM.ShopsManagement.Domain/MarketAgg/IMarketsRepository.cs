using _0_Framework.Domain;
using ShopsManagement.Application.Contracts.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Domain.ShopsAgg
{
    public interface IMarketsRepository : IRepository<long,Markets>
    {
        EditMarkets GetDetails(long id);
        List<MarketViewModel> Search(MarketSearchModel searchModel);
        List<MarketViewModel> GetMarkets();
        string GetSlugById(long id);
    }
}
