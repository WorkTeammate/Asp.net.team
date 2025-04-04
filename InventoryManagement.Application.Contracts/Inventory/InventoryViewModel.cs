﻿namespace InventoryManagement.Application.Contracts.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string Product { get; set; }
        public long ProductId { get; set; }

        public long AccountId { get; set; }
        public string Accounts { get; set; }
        public double UnitPrice { get; set; }
        public bool InStock { get; set; }
        public string CreationDate { get; set; }
        public long CurrentCount { get; set; }
    }
}
