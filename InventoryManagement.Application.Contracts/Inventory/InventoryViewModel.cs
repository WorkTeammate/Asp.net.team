namespace InventoryManagement.Application.Contracts.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string Product { get; set; }
        public long ProductId { get; set; }

        public string MarketName { get; set; }
        public string Markets { get; set; }
        public long MarketId { get; set; }
        public double UnitPrice { get; set; }
        public bool InStock { get; set; }
        public string CreationDate { get; set; }
        public long CurrentCount { get; set; }
    }
}
