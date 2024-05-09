using Microsoft.AspNetCore.SignalR;
using Server.Infrastructure;
using Server.Services;

namespace Service.Hubs
{
	public partial class ServiceHub
	{
		public async Task GetAllPatients()
		{
			PatientRepository patientRepository = new();
			PatientService patientService = new(patientRepository);
			await Clients.Caller.SendAsync("GetAllPatients", patientService.GetAllPatients());
		}
	}
}
