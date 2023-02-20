using DiscountManagement.Application.Contract.Contract;
using DiscountManagement.Application.Contract.Dtos.ColleagueDiscounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Services;
using ShopManement.Application.Contracts.Contracts;

namespace ServiceHost.Areas.Administration.Pages.Discount.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public SearchColleagueDiscount search;
        public List<ColleagueDiscountDto> colleagueDiscounts;
        public SelectList Products;

        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IColleagueDiscountApplication colleagueDiscountApplication, IProductApplication productApplication)
        {
            _productApplication = productApplication;
            _colleagueDiscountApplication = colleagueDiscountApplication;
        }

        public void OnGet(SearchColleagueDiscount search)
        {
            Products = new SelectList(_productApplication.GetProducts(), "ID", "Name");
            colleagueDiscounts = _colleagueDiscountApplication.Search(search);
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineColleagueDiscount()
            {
                Products = _productApplication.GetProducts()
            };

            return Partial("Create", command);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscount defineColleagueDiscount)
        {

            var result = _colleagueDiscountApplication.Define(defineColleagueDiscount);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {

            var colleagueDiscount = _colleagueDiscountApplication.GetDetail(id);
            colleagueDiscount.Products = _productApplication.GetProducts();
            return Partial("Edit", colleagueDiscount);
        }

        public JsonResult OnPostEdit(EditColleagueDiscount editColleagueDiscount)
        {
            var result = _colleagueDiscountApplication.Edit(editColleagueDiscount);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            var result = _colleagueDiscountApplication.Remove(id);
            if (result.IsSuccedd)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            var result = _colleagueDiscountApplication.Restore(id);
            if (result.IsSuccedd)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
