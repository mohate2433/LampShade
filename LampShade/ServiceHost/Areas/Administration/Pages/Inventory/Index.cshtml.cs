using InventoryManagement.Application.Contracts.Contracts;
using InventoryManagement.Application.Contracts.Dtos.InventoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManement.Application.Contracts.Contracts;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public SearchInventory search;
        public List<InventoryDto> Inventory;
        public SelectList Products;

        private readonly IInventoryApplication _invetoryApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IInventoryApplication inventoryApplication, IProductApplication productApplication)
        {
            _productApplication = productApplication;
            _invetoryApplication = inventoryApplication;
        }

        public void OnGet(SearchInventory search)
        {
            Products = new SelectList(_productApplication.GetProducts(), "ID", "Name");
            Inventory = _invetoryApplication.Search(search);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory()
            {
                Products = _productApplication.GetProducts()
            };

            return Partial("Create", command);
        }

        public JsonResult OnPostCreate(CreateInventory command)
        {

            var result = _invetoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {

            var inventory = _invetoryApplication.GetDetails(id);
            inventory.Products = _productApplication.GetProducts();
            return Partial("Edit", inventory);
        }

        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _invetoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory()
            {
                InventoryId = id
            };

            return Partial("Increase", command);
        }

        public JsonResult OnPostIncrease(IncreaseInventory command)
        {

            var result = _invetoryApplication.Increase(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetReduce(long id)
        {
            var command = new ReduceInventory()
            {
                InventoryId = id
            };

            return Partial("Reduce", command);
        }

        public JsonResult OnPostReduce(ReduceInventory command)
        {
            var result = _invetoryApplication.ReduceInventory(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetLog(long id)
        {
            var log = _invetoryApplication.GetInventoryOprations(id);

            return Partial("OprationLog", log);
        }
    }
}
