using _0_Framework.Domain;
using ShopManagement.Domain.DomainModels.ProductAggregate;

namespace ShopManagement.Domain.DomainModels.ProductCategoryAggregates
{
    public class ProductCategory : EntityBase
    {
        public string? Name { get; private set; }
        public string? Descripion { get; private set; }
        public string? Picture { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public string? Keywords { get; private set; }
        public string? MetaDescripion { get; private set; }
        public string? Slug { get; private set; }
        public List<Product> Products { get; private set; }

        public ProductCategory()
        {
            Products = new List<Product>();
        }

        public ProductCategory(string? name, string? descripion, string? picture,
            string? pictureAlt, string? pictureTitle, string? keywords,
            string? metaDescripion, string? slug)
        {
            Name = name;
            Descripion = descripion;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescripion = metaDescripion;
            Slug = slug;
        }

        public void Edite(string? name, string? descripion, string? picture,
            string? pictureAlt, string? pictureTitle, string? keywords,
            string? metaDescripion, string? slug)
        {
            Name = name;
            Descripion = descripion;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescripion = metaDescripion;
            Slug = slug;
        }
    }
}
