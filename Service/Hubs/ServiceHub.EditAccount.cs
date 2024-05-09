using Microsoft.AspNetCore.SignalR;
using Server.Infrastructure;
using Server.Services;

namespace Service.Hubs
{
	public partial class ServiceHub
	{
		public async Task EditAccount(string firstName, string lastName, string email, char sex, DateTime birthDay, string login)
		{
			if (!validation.Email(email) || !validation.FirstName(firstName) || !validation.LastName(lastName))
			{
				await Clients.Caller.SendAsync("EditAccountInvalid", validation.ErrorText);
			}
			else
			{
				UserRepository userRepository = new();
				UserService userService = new(userRepository);
				string message = userService.EditAccount(firstName, lastName, email, sex, birthDay, login);
				await Clients.Caller.SendAsync("EditAccountValid", message, firstName, lastName, email, sex, birthDay);
			}
		}
	}
}
