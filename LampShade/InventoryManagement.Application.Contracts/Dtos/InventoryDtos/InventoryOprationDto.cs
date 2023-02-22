namespace InventoryManagement.Application.Contracts.Dtos.InventoryDtos
{
    public class InventoryOprationDto
    {
        public long Id { get; set; }
        public bool Opration { get; set; }
        public long Count { get; set; }
        public long OpratorId { get; set; }
        public string? Oprator { get; set; }
        public string? OprationDate { get; set; }
        public long CurrentCount { get; set; }
        public string? Description { get; set; }
        public long OrderId { get; set; }
    }
}
