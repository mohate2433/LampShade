namespace InventoryManagement.Application.Contracts.Dtos.InventoryDtos
{
    public class CreateInventory
    {
        public long ProductId { get; set; }
        public double UnitPrice { get; set; }
    }
}
