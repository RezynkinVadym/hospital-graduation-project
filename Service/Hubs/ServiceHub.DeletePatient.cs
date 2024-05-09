using Microsoft.AspNetCore.SignalR;
using Server.Entities;
using Server.Infrastructure;
using Server.Services;
using SharedLibrary;

namespace Service.Hubs
{
	public partial class ServiceHub
	{
		public async Task DeletePatient(long id)
		{
				PatientRepository patientRepository = new();
				PatientService patientService = new(patientRepository);
				patientService.DeletePatient(id);
				await Clients.Caller.SendAsync("DeletePatient", id);
		}
	}
}
