using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustomerDiscount : EntityBase
    {
        public long ProductId { get; private set; }
        public long MarketId { get; private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Reason { get; private set; }

        protected CustomerDiscount()
        {

        }

        public CustomerDiscount(long productId, long marketId, int discountRate, 
            DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            MarketId = marketId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }

        public void Edit(long productId, long marketId, int discountRate,
            DateTime startDate, DateTime endDate, string reason)
        {
            ProductId = productId;
            MarketId = marketId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }
    }
}
