using _01_LampShadeQuery.Contract;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Domain.DomainModels.ProductCategoryAggregates;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryWithProductViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryWithProductViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var productCategories = _productCategoryQuery.GetProductCategoryWithProducts();
            return View(productCategories);
        }
    }
}
