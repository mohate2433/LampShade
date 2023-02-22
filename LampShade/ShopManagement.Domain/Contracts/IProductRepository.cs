using _0_Framework.Domain;
using ShopManagement.Domain.DomainModels.ProductAggregate;
using ShopManement.Application.Contracts.Dtos.ProductDtos;

namespace ShopManagement.Domain.Contracts
{
    public interface IProductRepository : IRepository<long , Product>
    {
        List<ProductDto> GetProducts();
        List<ProductDto> Search(SearechProductDto searech);
        EditProductDto GetDetails(long id);
    }
}
