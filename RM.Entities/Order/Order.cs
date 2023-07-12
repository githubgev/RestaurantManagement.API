namespace RM.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }

        public int CustomerId { get; set; }

        public bool TakeAway { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderStateId { get; set; }

        public decimal Sum { get; set; }

        public ICollection<OrderMenu> OrderMenu { get; set; }
    }
}