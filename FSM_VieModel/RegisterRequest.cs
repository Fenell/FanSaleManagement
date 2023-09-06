using System.Security.AccessControl;

namespace FSM_ViewModel;

public class RegisterRequest
{
	public string UserName { get; set; }
	public string Password { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
}