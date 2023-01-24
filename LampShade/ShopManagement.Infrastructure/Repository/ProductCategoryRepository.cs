using ShopManagement.Domain.DomainModels.ProductCategoryAggregates;
using ShopManagement.Domain.Services.Contracts;
using ShopManement.Application.Contracts.Dtos.ProductCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Repository
{
    public class ProductCategoryRepository : _0_Framework.Infrastructure.Repository<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopDbContext _context;

        public ProductCategoryRepository(ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public EditeProductCategoryDto GetDetails(long id) => _context.ProductCategories.Select(s => new EditeProductCategoryDto()
        {
            ID = s.ID,
            Name = s.Name,
            Descripion = s.Descripion,
            Picture = s.Picture,
            PictureAlt = s.PictureAlt,
            PictureTitle = s.PictureTitle,
            Keywords = s.Keywords,
            MetaDescripion = s.MetaDescripion,
            Slug = s.Slug
        }).FirstOrDefault(f => f.ID == id);

        public List<ProductCategoryDto> Search(SearchProductCategoryDto searchProduct)
        {
            var dtoList = _context.ProductCategories.Select(s => new ProductCategoryDto()
            {
                ID = s.ID,
                Name = s.Name,
                Picture = s.Picture,
                CreationDate = s.CreationDate.ToString()
            });

            if (!string.IsNullOrWhiteSpace(searchProduct.Name))
                dtoList = dtoList.Where(w => w.Name.Contains(searchProduct.Name));
            return dtoList.OrderByDescending(o => o.ID).ToList();
        }
    }
}
