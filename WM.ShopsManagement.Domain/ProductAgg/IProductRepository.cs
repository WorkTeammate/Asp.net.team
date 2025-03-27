using _01_Framework.Domain;
using ShopsManagement.Application.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long, Product>
    {
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        EditProduct GetDetails(long id);
    }
}
