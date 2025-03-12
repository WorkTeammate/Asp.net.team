﻿using _0_Framework.Application;
using ShopsManagement.Application.Contracts.Products;
using ShopsManagement.Application.Contracts.Shops;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public class CreateInventory
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }
        [Range(1000, double.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public double UnitPrice { get; set; }

        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]

        public long MarketId { get; set; }

        public List<ProductViewModel> Product { get; set; }
        public List<MarketViewModel> Market { get; set; }
    }
}
