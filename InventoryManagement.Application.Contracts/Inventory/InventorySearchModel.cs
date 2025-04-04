namespace InventoryManagement.Application.Contracts.Inventory
{
    public class InventorySearchModel
    {
        public long ProductId { get; set; }
        public long AccountId { get; set; }
        public bool Instock { get; set; }
    }
}
