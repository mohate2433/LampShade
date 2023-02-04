using _01_LampShadeQuery.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategory;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategory)
        {
            _productCategory = productCategory;
        }
        
        public IViewComponentResult Invoke()
        {
            var productCategories = _productCategory.GetProductCategories();
            return View(productCategories);
        }
    }
}
