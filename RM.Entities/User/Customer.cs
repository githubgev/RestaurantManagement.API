namespace RM.Entities
{
	public class Customer : BaseEntity
	{
        public int OrderId { get; set; }

        public int OnsiteTableId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}