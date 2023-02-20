using _0_Framework.Domain;
using System.Security.Permissions;

namespace InventoryManagement.Domain.InventoryAggregate
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; set; }
        public double UnitPrice { get; set; }
        public bool InStock { get; set; }
        public List<InventoryOpration>? Oprations { get; set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }

        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public long CalculateCurrentCount()
        {
            var plus = Oprations.Where(x=>x.Opration).Sum(x=>x.Count);
            var minus = Oprations.Where(x => !x.Opration).Sum(x => x.Count);
            return plus + minus;
        }

        public void Increase(long Count , long OpratorId , string? Description)
        { 
            var currentCount = CalculateCurrentCount() + Count;
            var inventoryOpration = new InventoryOpration(true , Count, OpratorId , currentCount  , Description , 0, ID);
            Oprations.Add(inventoryOpration);
            InStock = currentCount > 0;
        }

        public void Reduce(long Count, long OpratorId, string? Description, long OrderId)
        {
            var currentCount = CalculateCurrentCount()- Count;
            var inventoryOpration = new InventoryOpration(true, Count, OpratorId, currentCount, Description, OrderId, ID);
            Oprations.Add(inventoryOpration);
            InStock = currentCount > 0;
        }
    }
}
