using _0_Framework.Application;
using ShopManement.Application.Contracts.Dtos.ProductDtos;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contract.Dtos.CustomerDiscounts
{
    public class DefineCustomerDiscount
    {
        [Range(1, 10000000, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 99, ErrorMessage = ValidationMessage.IsRequired)]
        public int DiscountRate { get; set; }

        [Required( ErrorMessage = ValidationMessage.IsRequired)]
        public string? StartDate { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? EndDate { get; set; }

        public string? Reason { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
}
