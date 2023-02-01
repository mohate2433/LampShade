using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.DomainModels.ProductAggregate;
using ShopManement.Application.Contracts.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Repository
{
    public class ProductRepository : Repository<long, Product>, IProductRepository
    {
        private readonly ShopDbContext _context;

        public ProductRepository(ShopDbContext context) : base(context) => _context = context;

        public EditProductDto GetDetails(long id)
        {
            return _context.Products.Select(x => new EditProductDto()
            {
                ID = x.ID,
                Name = x.Name,
                Code = x.Code,
                UnitPrice =x.UnitPrice,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle =x.PictureTitle,
                Slug = x.Slug,
                Keywords =x.Keywords,
                MetaDescription=x.MetaDescription,
                CategoryID = x.CategoryID,
                
            }).FirstOrDefault(X=>X.ID == id);
        }

        public List<ProductDto> GetProducts()
        {
            return _context.Products.Select(x => new ProductDto
            {
                ID = x.ID,
                Name = x.Name
            }).ToList();
        }

        public List<ProductDto> Search(SearechProductDto searech)
        {
            var query = _context.Products.Include(x => x.Category).Select(x => new ProductDto()
            {
                ID = x.ID,
                Category=x.Category.Name,
                CategoryId = x.CategoryID,
                Name = x.Name,
                Code = x.Code,
                Picture = x.Picture,
                UnitPrice =x.UnitPrice,
                IsInStock = x.IsInStock,
                CreationDate = x.CreationDate.ToString()                
            });
            if (!string.IsNullOrWhiteSpace(searech.Name))
                query = query.Where(x=>x.Name == searech.Name);
            if(!string.IsNullOrWhiteSpace(searech.Code))
                query = query.Where(x=>x.Code == searech.Code);
            if (searech.CategoryID !=0)
                query = query.Where(x => x.CategoryId == searech.CategoryID);
            return query.OrderByDescending(x=>x.ID).ToList();
        }

    }
}
