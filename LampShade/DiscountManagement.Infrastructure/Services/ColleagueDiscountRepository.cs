using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.Dtos.ColleagueDiscounts;
using DiscountManagement.Domain.ColleagueDiscountAggregate;
using DiscountManagement.Domain.Contract;
using ShopManagement.Infrastructure;

namespace DiscountManagement.Infrastructure.Services
{
    public class ColleagueDiscountRepository : Repository<long, ColleagueDiscount> , IColleagueDiscountRepository
    {
        private readonly DiscountDbContext _context;
        private readonly ShopDbContext _shopContext;
        public ColleagueDiscountRepository(DiscountDbContext context , ShopDbContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditColleagueDiscount GetDetail(long id)
        {
            var colleagueDiscount = _context.ColleagueDiscount.Select(x => new EditColleagueDiscount
            {
                Id = x.ID,
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId
            }).FirstOrDefault(x => x.Id == id);
            return colleagueDiscount;
        }

        public List<ColleagueDiscountDto> Search(SearchColleagueDiscount search)
        {
            var products = _shopContext.Products.Select(x => new { x.ID , x.Name}).ToList();
            var query = _context.ColleagueDiscount.Select(x => new ColleagueDiscountDto
            {
                Id = x.ID,
                ProductId = x.ProductId,
                CreationDate = x.CreationDate.ToFarsi(),
                DiscountRate = x.DiscountRate,
                IsRemoved = x.IsRemoved
            });
            if(search.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == search.ProductId);
            }
            var discount = query.OrderByDescending(x => x.ProductId == search.ProductId).ToList();
            discount.ForEach(discount =>
            discount.Product = products.FirstOrDefault(x => x.ID == discount.ProductId)?.Name);
            return discount;
        }
    }
}
