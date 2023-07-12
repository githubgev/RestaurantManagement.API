namespace RM.Entities
{
	public class User : BaseEntity
	{
		public int RoleId { get; set; }

		public string FirstName { get; set; } 
		
		public string LastName { get; set; }
	}
}