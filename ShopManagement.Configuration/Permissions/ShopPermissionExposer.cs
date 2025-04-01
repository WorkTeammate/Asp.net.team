using _01_Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Product", new List<PermissionDto>
                    {
                        new PermissionDto(ShopsPermissions.ListProduct, "لیست محصول ها"),
                        new PermissionDto(ShopsPermissions.CreateProduct, "ایجاد محصول ها "),
                        new PermissionDto(ShopsPermissions.EditProduct, "ویرایش محصول ها "),
                        new PermissionDto(ShopsPermissions.SearchProduct, "جستجو محصول ها "),
                        new PermissionDto(ShopsPermissions.RemoveProduct, "حذف محصول ها "),
                        new PermissionDto(ShopsPermissions.RestoreProduct, "بازگردانی محصول ها "),
                    }
                },
                  {
                    "ProductCategory", new List<PermissionDto>
                    {
                        new PermissionDto(ShopsPermissions.ListProductCategory, "لیست محصول ها"),
                        new PermissionDto(ShopsPermissions.CreateProductCategory, "ایجاد محصول ها "),
                        new PermissionDto(ShopsPermissions.EditProductCategory, "ویرایش محصول ها "),
                        new PermissionDto(ShopsPermissions.SearchProductCategory, "جستجو محصول ها "),
                        new PermissionDto(ShopsPermissions.RemoveProductCategory, "حذف  دسته بندی محصول ها "),
                        new PermissionDto(ShopsPermissions.RestoreProductCategory, "بازگردانی دسته بندی محصول ها "),
                    }
                },
            };
        }
    }
}
