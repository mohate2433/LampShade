using _0_Framework.Application;
using ShopManement.Application.Contracts.Dtos.SlideDtos;

namespace ShopManement.Application.Contracts.Contracts
{
    public interface ISlideApplication
    {
        OprationResult Create(CreateSlideDto command);
        OprationResult Edit(EditSlideDto command);
        OprationResult Remove(long id);
        OprationResult Restore(long id);
        EditSlideDto GetDetails(long id);
        List<SlideDto> GetSlides();
    }
}