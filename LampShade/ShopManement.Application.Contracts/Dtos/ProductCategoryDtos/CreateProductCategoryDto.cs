namespace ShopManement.Application.Contracts.Dtos.ProductCategoryDtos
{
    public class CreateProductCategoryDto
    {
        public string? Name { get; set; }
        public string? Descripion { get; set; }
        public string? Picture { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
        public string? Keywords { get; set; }
        public string? MetaDescripion { get; set; }
        public string? Slug { get; set; }
    }
}
