using _0_Framework.Application;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult DefineCustomerDiscount(DefineCustomerDiscount command)
        {
            var operation = new OperationResult();
            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.MarketId == x.MarketId && x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);


            var startDate = command.StartDate.ToGeorgianDateTime();
            var EndDate = command.EndDate.ToGeorgianDateTime();

            var CustomerDiscount = new CustomerDiscount(command.ProductId, command.MarketId, command.DiscountRate, startDate
                , EndDate, command.Reason);

            _customerDiscountRepository.Create(CustomerDiscount);
            _customerDiscountRepository.SaveChanges();

            return operation.Successful();
        }

        public OperationResult EditCustomerDiscount(EditCustomerDiscount command)
        {
            var operation = new OperationResult();
            var CustomerDiscount = _customerDiscountRepository.Get(command.Id);

            if (CustomerDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId
            && x.MarketId == command.MarketId && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var startDate = command.StartDate.ToGeorgianDateTime();
            var EndDate = command.EndDate.ToGeorgianDateTime();

            CustomerDiscount.Edit(command.ProductId, command.MarketId, command.DiscountRate, startDate
                , EndDate, command.Reason);

            _customerDiscountRepository.SaveChanges();

            return operation.Successful();


        }

        public EditCustomerDiscount GetDetails(long Id)
        {
           return _customerDiscountRepository.GetDetails(Id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }
}
