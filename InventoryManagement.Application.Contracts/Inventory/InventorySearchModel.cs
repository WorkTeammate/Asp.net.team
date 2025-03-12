namespace InventoryManagement.Application.Contracts.Inventory
{
    public class InventorySearchModel
    {
        public long ProductId { get; set; }
        public long MarketId { get; set; }
        public bool Instock { get; set; }
    }
}
