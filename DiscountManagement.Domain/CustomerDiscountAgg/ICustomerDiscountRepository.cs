using _01_Framework.Domain;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IRepository<long,CustomerDiscount>
    {
        EditCustomerDiscount GetDetails(long Id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
    }
}
