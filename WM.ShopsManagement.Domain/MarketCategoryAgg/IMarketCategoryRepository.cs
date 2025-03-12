using _0_Framework.Domain;
using ShopsManagement.Application.Contracts.MarketCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Domain.MarketCategoryAgg
{
    public interface IMarketCategoryRepository : IRepository<long,MarketCategory>
    {
        EditMarketCategory GetDetails(long id);
        List<MarketCategoryViewModel> Search(MarketCategorySearchModel searchModel);
        List<MarketCategoryViewModel> GetMarketCategories();
    }
}
