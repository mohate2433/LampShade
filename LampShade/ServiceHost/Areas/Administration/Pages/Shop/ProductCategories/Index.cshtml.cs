using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManement.Application.Contracts.Contracts;
using ShopManement.Application.Contracts.Dtos.ProductCategoryDtos;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        public SearchProductCategoryDto search;
        public List<ProductCategoryDto> productCategoryDtos;

        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(SearchProductCategoryDto search)
        {
            productCategoryDtos = _productCategoryApplication.Search(search);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("Create" , new CreateProductCategoryDto());
        }

        public JsonResult OnPostCreate(CreateProductCategoryDto createProductCategoryDto)
        {
            var result =  _productCategoryApplication.Create(createProductCategoryDto);
            return new JsonResult(result);
        }
        
        public IActionResult OnGetEdit(long id)
        {
            var product = _productCategoryApplication.GetDetails(id);
            return Partial("Edit", product);
        }

        public JsonResult OnPostEdit(EditeProductCategoryDto editeProductCategoryDto)
        {
            var result = _productCategoryApplication.Edite(editeProductCategoryDto);
            return new JsonResult(result);
        }
    }
}
