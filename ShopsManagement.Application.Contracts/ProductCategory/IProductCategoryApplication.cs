using _01_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        OperationResult Delete(long id);
        OperationResult Restore(long id);
        List<ProductCategoryViewModel> GetProductCategories();
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        EditProductCategory GetDetails(long id);
    }
}
