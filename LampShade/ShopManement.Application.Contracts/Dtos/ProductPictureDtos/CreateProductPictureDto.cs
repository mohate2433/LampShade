using _0_Framework.Application;
using ShopManement.Application.Contracts.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManement.Application.Contracts.Dtos.ProductPictureDtos
{
    public class CreateProductPictureDto
    {
        public List<ProductDto> products;

        [Range(1, 1000000, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductID { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Picture { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureTitle { get; set; }
    }
}
