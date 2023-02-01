using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManement.Application.Contracts.Contracts;
using ShopManement.Application.Contracts.Dtos.ProductPictureDtos;
using ShopManement.Application.Contracts.Dtos.SlideDtos;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public List<SlideDto> SlideDto;

        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
            SlideDto = _slideApplication.GetSlides();
        }

        public IActionResult OnGetCreate()
        {
            return Partial("Create", new CreateSlideDto());
        }

        public JsonResult OnPostCreate(CreateSlideDto createSlideDto)
        {

            var result = _slideApplication.Create(createSlideDto);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Result = _slideApplication.GetDetails(id);
            return Partial("Edit", Result);
        }

        public JsonResult OnPostEdit(EditSlideDto editSlideDto)
        {
            var result = _slideApplication.Edit(editSlideDto);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _slideApplication.Remove(id);
            if (result.IsSuccedd)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            var result = _slideApplication.Restore(id);
            if (result.IsSuccedd)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
