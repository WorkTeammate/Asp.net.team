using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Configuration.Permissions
{
    public class ShopsPermissions
    {
        //Product 
        public const int CreateProduct = 1;
        public const int EditProduct = 2;
        public const int ListProduct = 3;
        public const int SearchProduct = 4;
        public const int RemoveProduct = 5;
        public const int RestoreProduct = 6;

        //Product Category
        public const int CreateProductCategory = 10;
        public const int EditProductCategory = 11;
        public const int ListProductCategory = 12;
        public const int SearchProductCategory = 13;
        public const int RemoveProductCategory = 14;
        public const int RestoreProductCategory = 15;

    }
}
