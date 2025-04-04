using _01_Framework.Domain;
using Market.ShopsManagement.Domain.ProductsAgg;
using ShopsManagement.Application.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Domain.ProductsAgg
{
    public interface IProductRepository : IRepository<long,Products>
    {
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        EditProduct GetDetails(long id);
        string GetSlugById(long id);
    }
}
