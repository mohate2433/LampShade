using _0_Framework.Domain;
using DiscountManagement.Application.Contract.Dtos.ColleagueDiscounts;
using DiscountManagement.Domain.ColleagueDiscountAggregate;

namespace DiscountManagement.Domain.Contract
{
    public interface IColleagueDiscountRepository : IRepository<long , ColleagueDiscount>
    {
        EditColleagueDiscount GetDetail(long id);
        List<ColleagueDiscountDto> Search(SearchColleagueDiscount search);
    }
}
