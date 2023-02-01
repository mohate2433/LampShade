using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.DomainModels.ProductPictureAggregates;
using ShopManement.Application.Contracts.Dtos.ProductPictureDtos;

namespace ShopManagement.Infrastructure.Repository
{
    public class ProductPictureRepository : Repository<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopDbContext _context;

        public ProductPictureRepository(ShopDbContext context) : base(context)
        {
            _context = context;
        }
        
        public EditProductPictureDto GetDetails(long id)
        {
            return _context.ProductPictures.Select(x=>new EditProductPictureDto
            {
                ID = x.ID,
                Picture = x.Picture,
                PictureAlt= x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductID = x.ProductID
            }).FirstOrDefault(p => p.ID == id);
        }

        public List<ProductPictureDto> Search(SearchProductPictureDto search)
        {
            var query = _context.ProductPictures.Include(x => x.Product).Select(x => new ProductPictureDto
            {
                ID = x.ID,
                ProductID = x.ProductID,
                Picture = x.Picture,
                Product = x.Product.Name,
                CreationDate = x.CreationDate.ToString(),
                IsRemoved = x.IsRemoved
            });
            if (search.ProductID!=0)
            {
                query = query.Where(x => x.ProductID == search.ProductID);
            }
            return query.OrderByDescending(x => x.ID).ToList();
        }
    }
}
