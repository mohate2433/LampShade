using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ShopManement.Application.Contracts.Dtos.ProductCategoryDtos
{
    public class CreateProductCategoryDto
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Name { get; set; }
        public string? Descripion { get; set; }
        public string? Picture { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Keywords { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? MetaDescripion { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Slug { get; set; }
    }
}
