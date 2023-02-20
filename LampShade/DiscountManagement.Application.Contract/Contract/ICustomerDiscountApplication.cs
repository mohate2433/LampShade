using _0_Framework.Application;
using DiscountManagement.Application.Contract.Dtos.CustomerDiscounts;

namespace DiscountManagement.Application.Contract.Contract
{
    public interface ICustomerDiscountApplication
    {
        OprationResult Define(DefineCustomerDiscount command);
        OprationResult Edit(EditCustomerDiscount command);
        EditCustomerDiscount GetDetail(long id);
        List<CustomerDiscountDto> Search(SearchCustomerDiscountDto search);
    }
}
