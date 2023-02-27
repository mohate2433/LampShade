using _0_Framework.Application;
using ShopManement.Application.Contracts.Dtos.ProductCategoryDtos;
using System.ComponentModel.DataAnnotations;

namespace ShopManement.Application.Contracts.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string? Name { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Code { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Slug { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Keywords { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? MetaDescription { get; set; }
        [Range(1,100000,ErrorMessage =ValidationMessage.IsRequired)]
        public long CategoryID { get; set; }
        public List<ProductCategoryDto>? Categories { get; set; }
    }
}
