using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Configuration.Permissions
{
    public class ShopsPermissions
    {
        //Market 
        public const int CreateMarket = 1;
        public const int EditMarket = 2;
        public const int ListMarket = 3;
        public const int SearchMarket = 4;

        //Market Category
        public const int CreateMarketCategory = 10;
        public const int EditMarketCategory = 11;
        public const int ListMarketCategory = 12;
        public const int SearchMarketCategory = 13;


        //Product
        public const int ListProducts = 20;
        public const int SearchProducts = 21;
        public const int CreateProduct = 22;
        public const int EditProduct = 23;
    }
}
