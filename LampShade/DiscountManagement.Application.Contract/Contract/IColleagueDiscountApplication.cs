using _0_Framework.Application;
using DiscountManagement.Application.Contract.Dtos.ColleagueDiscounts;

namespace DiscountManagement.Application.Contract.Contract
{
    public interface IColleagueDiscountApplication
    {
        OprationResult Define(DefineColleagueDiscount command);
        OprationResult Edit(EditColleagueDiscount command);
        OprationResult Remove(long id);
        OprationResult Restore(long id);
        EditColleagueDiscount GetDetail(long id);
        List<ColleagueDiscountDto> Search(SearchColleagueDiscount search);
    }
}
