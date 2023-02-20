namespace DiscountManagement.Application.Contract.Dtos.CustomerDiscounts
{
    public class SearchCustomerDiscountDto
    {
        public long ProductId { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
