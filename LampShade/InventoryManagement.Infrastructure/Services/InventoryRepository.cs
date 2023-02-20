using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contracts.Dtos.InventoryDtos;
using InventoryManagement.Domain.Contracts;
using InventoryManagement.Domain.InventoryAggregate;
using ShopManagement.Infrastructure;

namespace InventoryManagement.Infrastructure.Services
{
    public class InventoryRepository : Repository<long , Inventory> , IInventoryRepository
    {
        private readonly InventoryDbContext _context;
        private readonly ShopDbContext _shopContext;
        public InventoryRepository(InventoryDbContext context,ShopDbContext shopContext) : base(context)
        {
            _shopContext = shopContext;
            _context = context;
        }

        public Inventory GetInventory(long id) => _context.Inventory.FirstOrDefault(x => x.ID == id);
        
        public EditInventory GetDetails(long id) => _context.Inventory.Select(x => new EditInventory
            {
                Id = x.ID,
                ProductId= x.ProductId,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);

        public List<InventoryDto> Search(SearchInventory search)
        {
            var products = _shopContext.Products.Select(x => new { x.ID, x.Name }).ToList();
            var query = _context.Inventory.Select(x => new InventoryDto
            {
                Id =x.ID,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                CurrentCount = x.CalculateCurrentCount()
            });
            if (search.ProductId > 0)
                query = query.Where(x => x.ProductId == search.ProductId);
            if (!search.InStock)
                query = query.Where(x => !x.InStock);

            var Inventory = query.OrderByDescending(x => x.Id).ToList();
            Inventory.ForEach(item =>
            {
                item.Product = products.FirstOrDefault(x => x.ID == search.ProductId)?.Name;
            });
            return Inventory;

        }
    }
}
