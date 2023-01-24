namespace ShopManement.Application.Contracts.Dtos.ProductCategoryDtos
{
    public class ProductCategoryDto
    {
        public long ID { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public string? CreationDate { get; set; }
        public string? ProductsCount { get; set; }
    }
}
