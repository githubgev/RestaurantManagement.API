namespace RM.Entities
{
	public enum Role
	{
		Manager,
		Waiter
	}

	public enum OrderState
	{
		Pending,
		Processing,
		Closed,
		Cancelled,
		Rejected
	}
}