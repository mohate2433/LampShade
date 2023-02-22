namespace _01_LampShadeQuery.Model
{
    public class ProductCategoryQueryModel
    {
        public long ID { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
        public string? Slug { get; set; }
        public List<ProductQueryModel>? Products { get; set; }
    }
}
