namespace RM.Entities
{
	public class Menu : BaseEntity
	{
		public string Name { get; set; }

		public decimal Price { get; set; }

        public ICollection<MenuProduct> MenuProducts { get; set; }

        public ICollection<OrderMenu> OrderMenu { get; set; }
    }
}