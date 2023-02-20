using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.Dtos.CustomerDiscounts;
using DiscountManagement.Domain.Contract;
using DiscountManagement.Domain.CustomerDiscountAggregate;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.Services
{
    public class CustomerDiscountRepository : Repository<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountDbContext _context;
        private readonly ShopDbContext _shopContext;

        public CustomerDiscountRepository(DiscountDbContext context, ShopDbContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount GetDetail(long id)
        {
            return _context.CustomerDiscount.Select(x => new EditCustomerDiscount()
            {
                ID = x.ID,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi(),
                Reason = x.Reason
            }).FirstOrDefault(x => x.ID == id);
        }

        public List<CustomerDiscountDto> Search(SearchCustomerDiscountDto search)
        {
            var products = _shopContext.Products.Select(x => new { x.ID, x.Name }).ToList();
            var query = _context.CustomerDiscount.Select(x => new CustomerDiscountDto()
            {
                Id = x.ID,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi(),
                StartDateGr = x.StartDate,
                EndDateGr = x.EndDate,
                Reason = x.Reason,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (search.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == search.ProductId);
            }

            if(!string.IsNullOrWhiteSpace(search.StartDate))
            {
                query = query.Where(x => x.StartDateGr > search.StartDate.ToGeorgianDateTime());
            }

            if(!string.IsNullOrWhiteSpace(search.EndDate))
            {
                query = query.Where(x => x.EndDateGr < search.EndDate.ToGeorgianDateTime());
            }
            var discounts = query.OrderByDescending(x => x.Id).ToList();

            discounts.ForEach(discount =>
            discount.Product = products.FirstOrDefault(x => x.ID == discount.ProductId)?.Name);
            return discounts;
        }
    }
}
