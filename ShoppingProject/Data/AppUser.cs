using Microsoft.AspNetCore.Identity;

namespace ShoppingProject.Data
{
	public class AppUser:IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
	}
}
