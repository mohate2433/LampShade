using ShopManement.Application.Contracts.Dtos.ProductCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManement.Application.Contracts.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public double UnitPrice { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public string? PictureAlt { get; set; }
        public string? PictureTitle { get; set; }
        public string? Slug { get; set; }
        public string? Keywords { get; set; }
        public string? MetaDescription { get; set; }
        public long CategoryID { get; set; }
        public List<ProductCategoryDto>? Categories { get; set; }
    }
}
