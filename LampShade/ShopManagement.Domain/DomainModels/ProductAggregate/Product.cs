﻿using _0_Framework.Domain;
using ShopManagement.Domain.DomainModels.ProductCategoryAggregates;
using ShopManagement.Domain.DomainModels.ProductPictureAggregates;

namespace ShopManagement.Domain.DomainModels.ProductAggregate
{
    public class Product : EntityBase
    {
        public string? Name { get; private set; }
        public string? Code { get; private set; }
        public string? ShortDescription { get; private set; }
        public string? Description { get; private set; }
        public string? Picture { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public string? Slug { get; private set; }
        public string? Keywords { get; private set; }
        public string? MetaDescription { get; private set; }
        public long CategoryID { get; private set; }
        public ProductCategory? Category { get; private set; }
        public List<ProductPicture> ProductPictures { get; private set; }

        public Product(string? name, string? code,string? shortDescription,
            string? description, string? picture,
            string? pictureAlt, string? pictureTitle, string? slug, string? keywords,
            string? metaDescription, long categoryID)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryID = categoryID;
        }
        
        public void Edit(string? name, string? code, string? shortDescription,
            string? description, string? picture,
            string? pictureAlt, string? pictureTitle, string? slug, string? keywords,
            string? metaDescription, long categoryID)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryID = categoryID;
        }
    }
}
