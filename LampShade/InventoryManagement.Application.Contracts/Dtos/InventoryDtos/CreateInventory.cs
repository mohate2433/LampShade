using _0_Framework.Application;
using ShopManement.Application.Contracts.Dtos.ProductDtos;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Contracts.Dtos.InventoryDtos
{
    public class CreateInventory
    {
        [Range(1 , 1000000, ErrorMessage =ValidationMessage.IsRequired)]
        public long ProductId { get; set; }
        [Range(1 , double.MaxValue, ErrorMessage =ValidationMessage.IsRequired)]
        public double UnitPrice { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
}
