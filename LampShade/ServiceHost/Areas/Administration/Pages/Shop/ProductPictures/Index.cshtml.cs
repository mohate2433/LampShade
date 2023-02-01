using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManement.Application.Contracts.Contracts;
using ShopManement.Application.Contracts.Dtos.ProductCategoryDtos;
using ShopManement.Application.Contracts.Dtos.ProductDtos;
using ShopManement.Application.Contracts.Dtos.ProductPictureDtos;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public SearchProductPictureDto searchPicture;
        public List<ProductPictureDto> productPictures;
        public SelectList Products;

        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }

        public void OnGet(SearchProductPictureDto search)
        {
            Products = new SelectList(_productApplication.GetProducts(), "ID", "Name");
            productPictures = _productPictureApplication.Search(search);
        }

        public IActionResult OnGetCreate()
        {
            var Command = new CreateProductPictureDto
            {
                products = _productApplication.GetProducts()
            };
            return Partial("Create", Command);
        }

        public JsonResult OnPostCreate(CreateProductPictureDto createProductPictureDto)
        {

            var result = _productPictureApplication.Create(createProductPictureDto);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {

            var product = _productPictureApplication.GetDetails(id);
            product.products = _productApplication.GetProducts();
            return Partial("Edit", product);
        }

        public JsonResult OnPostEdit(EditProductPictureDto editProductPictureDto)
        {
            var result = _productPictureApplication.Edit(editProductPictureDto);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _productPictureApplication.Remove(id);
            if (result.IsSuccedd)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            var result = _productPictureApplication.Restore(id);
            if (result.IsSuccedd)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
