namespace RM.Services
{
	public class CustomerDto : BaseEntity
	{
        public int OrderId { get; set; }

        public int OnsiteTableId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}