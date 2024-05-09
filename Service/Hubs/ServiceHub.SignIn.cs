using Microsoft.AspNetCore.SignalR;
using Server.Infrastructure;
using Server.Services;
using Server.Entities;

namespace Service.Hubs
{
	public partial class ServiceHub
	{
		public async Task SignIn(string login, string password)
		{

			if (!validation.Login(login))
			{
				await Clients.Caller.SendAsync("SignInInvalidLogin", validation.ErrorText);
			}
			else if (!validation.Password(password))
			{
				await Clients.Caller.SendAsync("SignInInvalidPassword", validation.ErrorText);
			}
			else
			{
				UserRepository userRepository = new();
				UserService userService = new(userRepository);
				User user = userService.SignIn(login, password);
				if(user == null)
				{
					await Clients.Caller.SendAsync("SignInIncorrectData", "");
				}
				else
					await Clients.Caller.SendAsync("SignInValid", user.FirstName, user.LastName, user.Email, user.Sex, user.BirthDay, user.Login);
			}
		}
	}
}
