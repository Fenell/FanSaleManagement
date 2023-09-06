using FSM_ViewModel;

namespace FSM_Application.Identity.Interface;

public interface IAuthService
{
	Task<string> Login(string username, string password);

	Task<RegisterReponse> Register(RegisterRequest request);
}