namespace RM.Entities
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }

        public ICollection<MenuProduct> MenuProducts { get; set; }
    }
}