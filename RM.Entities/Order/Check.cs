namespace RM.Entities
{
	public class Check
	{
		public DateTime OrderDate { get; set; }

		public List<Dish> Dishes { get; set; } = new List<Dish>();

		public decimal Sum { get; set; }
	}
}