using Microsoft.AspNetCore.SignalR;
using Server.Services;
using Server.Infrastructure;

namespace Service.Hubs
{
	public partial class ServiceHub
	{
		public async Task SecondStepRegistration(string login, string password)
		{
			if (!validation.Login(login))
			{
				await Clients.Caller.SendAsync("RegistrationInvalidLogin", validation.ErrorText);
			}
			else if (!validation.Password(password))
			{
				await Clients.Caller.SendAsync("RegistrationInvalidPassword", validation.ErrorText);
			}
			else
			{
				UserRepository userRepository = new();
				UserService userService = new(userRepository);
				string result = userService.RegisterUser(Context.ConnectionId, login, password);
				await Clients.Caller.SendAsync("SecondRegistrationValid", result);
			}
		}
	}
}
