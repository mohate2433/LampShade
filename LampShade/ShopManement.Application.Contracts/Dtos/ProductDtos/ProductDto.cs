namespace ShopManement.Application.Contracts.Dtos.ProductDtos
{
    public class ProductDto
    {
        public long ID { get; set; }
        public string? Picture { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public double UnitPrice { get; set; }
        public string? Category { get; set; }
        public long CategoryId { get; set; }
        public string? CreationDate { get; set; }
    }
}
