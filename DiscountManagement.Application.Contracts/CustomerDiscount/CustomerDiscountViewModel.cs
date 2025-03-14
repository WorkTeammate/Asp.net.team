namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long MarketId { get; set; }
        public string Product { get; set; }
        public string Market { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public DateTime StartDateGr { get; set; }
        public string EndDate { get; set; }
        public DateTime EndDateGr { get; set; }
        public string Reason { get; set; }
        public string CreationDate { get; set; }
    }
}
