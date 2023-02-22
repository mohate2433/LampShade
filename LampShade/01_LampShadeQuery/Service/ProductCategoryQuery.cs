using _01_LampShadeQuery.Contract;
using _01_LampShadeQuery.Model;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.DomainModels.ProductAggregate;
using ShopManagement.Infrastructure;

namespace _01_LampShadeQuery.Service
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopDbContext _context;

        public ProductCategoryQuery(ShopDbContext context)
        {
            _context = context;
        }
        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryQueryModel
            {
                ID = x.ID,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoryWithProducts()
        {
            return _context.ProductCategories.Include(x => x.Products).ThenInclude(x => x.Category).Select(x => new ProductCategoryQueryModel
            {
                ID = x.ID,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Products = MapProducts(x.Products)
            }).ToList();
        }

        private static List<ProductQueryModel> MapProducts(List<Product> products)
        {
            var result = new List<ProductQueryModel>();
            foreach (var item in products)
            {
                var product = new ProductQueryModel
                {
                    Id = item.ID,
                    Name = item.Name,
                    Picture = item.Picture,
                    PictureAlt = item.PictureAlt,
                    PictureTitle = item.PictureTitle,
                    Slug = item.Slug,
                    Category = item.Category.Name
                };
                result.Add(product);
            }
            return result;
        }
    }
}
