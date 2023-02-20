using _0_Framework.Application;
using ShopManement.Application.Contracts.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.Dtos.ColleagueDiscounts
{
    public class DefineColleagueDiscount
    {
        [Range(1,10000000 , ErrorMessage =ValidationMessage.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 99, ErrorMessage = ValidationMessage.IsRequired)]
        public int DiscountRate { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
}
