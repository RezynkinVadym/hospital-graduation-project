using Microsoft.AspNetCore.SignalR;
using Server;

namespace Service.Hubs
{
	public partial class ServiceHub
	{
		
		public async Task FirstStepRegistration(string firstName, string lastName, string email, char sex, DateTime dateOfBirth)
		{
			if (!validation.FirstName(firstName))
			{
					await Clients.Caller.SendAsync("RegistrationInvalidFirstName", validation.ErrorText);
			}
			else if(!validation.LastName(lastName))
			{
				await Clients.Caller.SendAsync("RegistrationInvalidLastName", validation.ErrorText);
			}
			else if (!validation.Email(email))
			{
				await Clients.Caller.SendAsync("RegistrationInvalidEmail", validation.ErrorText);
			}
			else
			{
				DataFirstStepRegistration.SaveUserData(Context.ConnectionId, firstName, lastName, email, sex, dateOfBirth);
				await Clients.Caller.SendAsync("FirstRegistrationValid", "");
			}
		}
	}
}
