namespace InventoryManagement.Application.Contracts.Dtos.InventoryDtos
{
    public class IncreaseInventory
    {
        public long InventoryId { get; set; }
        public string? Description { get; set; }
        public long Count { get; set; }
    }
}
