namespace InventoryManagement.Application.Contracts.Dtos.InventoryDtos
{
    public class SearchInventory
    {
        public long ProductId { get; set; }
        public bool InStock { get; set; }
    }
}
