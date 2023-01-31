using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManement.Application.Contracts.Contracts;
using ShopManement.Application.Contracts.Dtos.ProductCategoryDtos;
using ShopManement.Application.Contracts.Dtos.ProductDtos;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        public SearechProductDto search;
        public List<ProductDto> productDtos;
        public SelectList ProductCategpries;

        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication, IProductApplication productApplication)
        {
            _productCategoryApplication = productCategoryApplication;
            _productApplication = productApplication;
        }

        public void OnGet(SearechProductDto search)
        {
            ProductCategpries = new SelectList(_productCategoryApplication.GetProductCategories(), "ID", "Name");
            productDtos = _productApplication.Search(search);
        }

        public IActionResult OnGetCreate()
        {
            var Command = new CreateProductDto
            {
                Categories = _productCategoryApplication.GetProductCategories()
            };
            return Partial("Create", Command);
        }

        public JsonResult OnPostCreate(CreateProductDto createProductDto)
        {
            var result = _productApplication.Create(createProductDto);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _productApplication.GetDetails(id);
            return Partial("Edit", product);
        }

        public JsonResult OnPostEdit(EditProductDto editeProductDto)
        {
            var result = _productApplication.Edit(editeProductDto);
            return new JsonResult(result);
        }
    }
}
