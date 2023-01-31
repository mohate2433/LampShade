using _0_Framework.Application;
using ShopManement.Application.Contracts.Dtos.ProductCategoryDtos;

namespace ShopManement.Application.Contracts.Contracts
{
    public interface IProductCategoryApplication
    {
        OprationResult Create(CreateProductCategoryDto productCategoryDto);
        OprationResult Edite(EditeProductCategoryDto productCategoryDto);
        EditeProductCategoryDto GetDetails(long id);
        List<ProductCategoryDto> GetProductCategories();
        List<ProductCategoryDto> Search(SearchProductCategoryDto productCategoryDto);
    }
}
