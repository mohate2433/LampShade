using DiscountManagement.Application.Contract.Contract;
using DiscountManagement.Application.Contract.Dtos.CustomerDiscounts;
using DiscountManagement.Domain.CustomerDiscountAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManement.Application.Contracts.Contracts;
using ShopManement.Application.Contracts.Dtos.ProductDtos;

namespace ServiceHost.Areas.Administration.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public SearchCustomerDiscountDto search;
        public List<CustomerDiscountDto> customerDiscounts;
        public SelectList Products;

        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel( IProductApplication productApplication, ICustomerDiscountApplication customerDiscountApplication)
        {
            _productApplication = productApplication;
            _customerDiscountApplication = customerDiscountApplication;
        }

        public void OnGet(SearchCustomerDiscountDto search)
        {
            Products = new SelectList(_productApplication.GetProducts(), "ID", "Name");
            customerDiscounts = _customerDiscountApplication.Search(search);
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscount()
            {
                Products = _productApplication.GetProducts()
            };

            return Partial("Create", command);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount defineCusomerDiscount)
        {

            var result = _customerDiscountApplication.Define(defineCusomerDiscount);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {

            var customerDiscount = _customerDiscountApplication.GetDetail(id);
            customerDiscount.Products = _productApplication.GetProducts();
            return Partial("Edit", customerDiscount);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount editCustomerDiscount)
        {
            var result = _customerDiscountApplication.Edit(editCustomerDiscount);
            return new JsonResult(result);
        }
    }
}
