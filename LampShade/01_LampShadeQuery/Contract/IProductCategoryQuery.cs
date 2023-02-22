using _01_LampShadeQuery.Model;

namespace _01_LampShadeQuery.Contract
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoryWithProducts();
    }
}
