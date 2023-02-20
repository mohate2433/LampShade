namespace InventoryManagement.Domain.InventoryAggregate
{
    public class InventoryOpration
    {
        public long Id { get; set; }
        public bool Opration { get; set; }  
        public long Count { get; set; }
        public long OpratorId { get; set; }
        public DateTime OprationDate { get; set; }
        public long CurrentCount { get; set; }
        public string? Description { get; set; }
        public long OrderId { get; set; }
        public long InventotyId { get; set; }
        public Inventory? Inventory { get; set; }

        public InventoryOpration()
        {

        }
        public InventoryOpration(bool opration, long count, long opratorId, long currentCount, string? description, long orderId, long inventotyId)
        {
            Opration = opration;
            Count = count;
            OpratorId = opratorId;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventotyId = inventotyId;
        }
    }
}
