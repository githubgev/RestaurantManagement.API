namespace RM.Entities
{
	public class UserHistory
	{
		public int UserId { get; set; }

		public List<Order> Orders { get; set; } = new List<Order>();
	}
}