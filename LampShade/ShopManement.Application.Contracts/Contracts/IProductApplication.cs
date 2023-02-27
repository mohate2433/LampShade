using _0_Framework.Application;
using ShopManement.Application.Contracts.Dtos.ProductDtos;

namespace ShopManement.Application.Contracts.Contracts
{
    public interface IProductApplication
    {
        OprationResult Create(CreateProductDto createProductDto);
        OprationResult Edit(EditProductDto editProductDto);
        EditProductDto GetDetails(long id);
        List<ProductDto> GetProducts();
        List<ProductDto> Search(SearechProductDto searech);
    }
}
