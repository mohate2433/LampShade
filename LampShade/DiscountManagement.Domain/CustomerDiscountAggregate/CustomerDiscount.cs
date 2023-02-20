using _0_Framework.Domain;

namespace DiscountManagement.Domain.CustomerDiscountAggregate 
{
    public class CustomerDiscount : EntityBase
    {
        public long ProductId { get; set; }
        public int DiscountRate { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
        public string? Reason { get; set;}

        public CustomerDiscount(long productId, int discountRate, DateTime startDate, DateTime endDate, string? reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }
        public void Edit(long productId, int discountRate, DateTime startDate, DateTime endDate, string? reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }
    }
}
