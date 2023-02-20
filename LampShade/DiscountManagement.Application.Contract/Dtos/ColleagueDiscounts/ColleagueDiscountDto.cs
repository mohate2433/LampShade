namespace DiscountManagement.Application.Contract.Dtos.ColleagueDiscounts
{
    public class ColleagueDiscountDto
    {
        public long Id { get; set; }
        public long ProductId { get; set;}
        public int DiscountRate { get; set;}
        public string? Product { get; set; }
        public string? CreationDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}
