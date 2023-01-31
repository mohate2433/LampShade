using _0_Framework.Domain;
using ShopManagement.Domain.DomainModels.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.DomainModels.ProductCategoryAggregates
{
    public class ProductCategory : EntityBase
    {
        public string? Name { get; set; }
        public string? Descripion { get; set; }
        public string? Picture { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
        public string? Keywords { get; set; }
        public string? MetaDescripion { get; set; }
        public string? Slug { get; set; }
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
