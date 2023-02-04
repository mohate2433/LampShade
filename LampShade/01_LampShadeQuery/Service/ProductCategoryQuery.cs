using _01_LampShadeQuery.Contract;
using _01_LampShadeQuery.Model;
using ShopManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
