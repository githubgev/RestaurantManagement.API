namespace RM.Services
{
    public class OrderDto : BaseEntity
    {
        public int UserId { get; set; }

        public int CustomerId { get; set; }

        public bool TakeAway { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderStateId { get; set; }

        public double Sum { get; set; }

        public double Tip { get; set; }
    }
}