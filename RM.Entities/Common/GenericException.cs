using System.Net;

namespace RM.Entities
{
	public class GenericException : Exception
	{
		public HttpStatusCode StatusCode { get; }

		public override string Message { get; }

		public GenericException(HttpStatusCode status, string message)
		{
			StatusCode = status;
			Message = message;
		}
	}
}