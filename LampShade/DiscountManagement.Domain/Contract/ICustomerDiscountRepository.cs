using _0_Framework.Domain;
using DiscountManagement.Application.Contract.Dtos.CustomerDiscounts;
using DiscountManagement.Domain.CustomerDiscountAggregate;

namespace DiscountManagement.Domain.Contract
{
    public interface ICustomerDiscountRepository : IRepository<long , CustomerDiscount>
    {
        EditCustomerDiscount GetDetail(long id);
        List<CustomerDiscountDto> Search(SearchCustomerDiscountDto search);
    }
}
