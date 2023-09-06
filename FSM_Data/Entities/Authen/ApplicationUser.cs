using Microsoft.AspNetCore.Identity;

namespace FSM_Data.Entities.Authen;

public class ApplicationUser : IdentityUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
}