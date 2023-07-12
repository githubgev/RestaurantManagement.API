namespace RM.Services
{
	public class UserDto : BaseEntity
	{
		public int RoleId { get; set; }

		public string FirstName { get; set; } 
		
		public string LastName { get; set; }
	}
}