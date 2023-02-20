using _0_Framework.Application;
using DiscountManagement.Application.Contract.Contract;
using DiscountManagement.Application.Contract.Dtos.CustomerDiscounts;
using DiscountManagement.Domain.Contract;
using DiscountManagement.Domain.CustomerDiscountAggregate;

namespace DiscountManagement.Application.Services
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OprationResult Define(DefineCustomerDiscount command)
        {
            var opration = new OprationResult();
            if(_customerDiscountRepository.Exists(x=>x.ProductId == command.ProductId &&
            x.DiscountRate == command.DiscountRate))
                return opration.Failed(ApplicationMessages.DuplicatedMessage);

            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();
            var customerDiscount = new CustomerDiscount
                (
                command.ProductId,
                command.DiscountRate,
                startDate,
                endDate,
                command.Reason
                );
            _customerDiscountRepository.Create(customerDiscount);
            _customerDiscountRepository.SaveChanges();
            return opration.Succedded();
        }
        public OprationResult Edit(EditCustomerDiscount command)
        {
            var opration = new OprationResult();
            var customerDiscount = _customerDiscountRepository.Get(command.ID);
            if (customerDiscount == null) return opration.Failed(ApplicationMessages.NotFoundMessage);

            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId && 
                x.DiscountRate == command.DiscountRate && x.ID !=command.ID)) 
                return opration.Failed(ApplicationMessages.DuplicatedMessage);


            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();

            customerDiscount.Edit(command.ProductId, command.DiscountRate, startDate, endDate, command.Reason);
            _customerDiscountRepository.SaveChanges();
            return opration.Succedded();
        }

        public EditCustomerDiscount GetDetail(long id) =>
            _customerDiscountRepository.GetDetail(id);

        public List<CustomerDiscountDto> Search(SearchCustomerDiscountDto search) =>
            _customerDiscountRepository.Search(search);
    }
}
