namespace InventoryManagement.Application.Contracts.Dtos.InventoryDtos
{
    public class InventoryDto 
    {
        public long Id { get; set; }
        public string? Product { get; set; }
        public long ProductId { get; set; }
        public double UnitPrice { get; set; }
        public bool InStock { get; set; }
        public long CurrentCount { get; set; }
    }
}
