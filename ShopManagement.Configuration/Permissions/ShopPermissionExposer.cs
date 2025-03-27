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
                    "Market", new List<PermissionDto>
                    {
                        new PermissionDto(ShopsPermissions.ListMarket, "لیست فروشگاه ها"),
                        new PermissionDto(ShopsPermissions.CreateMarket, "ایجاد فروشگاه "),
                        new PermissionDto(ShopsPermissions.EditMarket, "ویرایش فروشگاه "),
                        new PermissionDto(ShopsPermissions.SearchMarket, "جستجو فروشگاه "),
                    }
                },
                {
                    "MarketCategory", new List<PermissionDto>
                    {
                        new PermissionDto(ShopsPermissions.ListMarketCategory, "لیست  دسته بندی فروشگاه ها"),
                        new PermissionDto(ShopsPermissions.CreateMarketCategory, "ایجاد دسته بندی فروشگاه "),
                        new PermissionDto(ShopsPermissions.EditMarketCategory, "ویرایش دسته بندی فروشگاه "),
                        new PermissionDto(ShopsPermissions.SearchMarketCategory, "جستجو دسته بندی فروشگاه "),
                    }
                },
                {
                    "Product", new List<PermissionDto>
                    {
                        new PermissionDto(ShopsPermissions.ListProducts, "لیست محصول ها"),
                        new PermissionDto(ShopsPermissions.CreateProduct, "ایجاد محصول ها "),
                        new PermissionDto(ShopsPermissions.EditProduct, "ویرایش محصول ها "),
                        new PermissionDto(ShopsPermissions.SearchProducts, "جستجو محصول ها "),
                    }
                }
            };
        }
    }
}
