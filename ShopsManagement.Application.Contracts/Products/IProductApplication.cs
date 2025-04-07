using _01_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application.Contracts.Products
{
    public interface IProductApplication
    {
        OperationResult CreateProduct(CreateProduct command);
        OperationResult EditProduct(EditProduct command);
        OperationResult Delete(long id);
        OperationResult Restore(long id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        EditProduct GetDetails(long id);
        OperationResult EditFileProduct(EditFileProduct command);
    }
}
