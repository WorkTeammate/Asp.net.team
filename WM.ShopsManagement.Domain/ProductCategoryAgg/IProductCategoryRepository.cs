using _01_Framework.Domain;
using ShopsManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long,ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategories();
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        EditProductCategory GetDetails(long id);
        string GetSlugById(long id);
    }
}
