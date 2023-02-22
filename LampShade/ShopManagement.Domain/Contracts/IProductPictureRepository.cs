using _0_Framework.Domain;
using ShopManagement.Domain.DomainModels.ProductPictureAggregates;
using ShopManement.Application.Contracts.Dtos.ProductPictureDtos;

namespace ShopManagement.Domain.Contracts
{
    public interface IProductPictureRepository : IRepository<long,ProductPicture>
    {
        EditProductPictureDto GetDetails(long id);
        List<ProductPictureDto> Search(SearchProductPictureDto search);
    }
}
