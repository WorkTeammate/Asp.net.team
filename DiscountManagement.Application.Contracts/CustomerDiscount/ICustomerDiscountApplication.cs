using _01_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult DefineCustomerDiscount(DefineCustomerDiscount command);
        OperationResult EditCustomerDiscount(EditCustomerDiscount command);
        EditCustomerDiscount GetDetails(long Id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
    }
}
