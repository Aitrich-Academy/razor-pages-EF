using JobPortalApplication.Models;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JobPortalApplication.Dtos
{
	public class ApplicationDto
	{
		public ApplicationDto(Guid id, Guid jobID, Guid userID)
		{
			Id = id;
			JobID = jobID;
			UserID = userID;
		}

		public Guid Id { get; set; }
		 public Guid JobID { get; set; }
		public Guid UserID { get; set; }
		

	}
}
