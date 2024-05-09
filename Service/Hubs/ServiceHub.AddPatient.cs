using Microsoft.AspNetCore.SignalR;
using Server.Infrastructure;
using Server.Services;
using SharedLibrary;

namespace Service.Hubs
{
	public partial class ServiceHub
	{
		public async Task AddPatient(string firstName, string lastName, DateTime birthDay, string phone, string diagnosis)
		{
			if (!validation.Diagnosis(diagnosis) || !validation.Phone(phone) || !validation.LastName(lastName) || !validation.FirstName(firstName))
			{
				await Clients.Caller.SendAsync("AddPatientInvalid", validation.ErrorText);
			}
			else
			{
				PatientRepository patientRepository = new();
				PatientService patientService = new(patientRepository);
				Patient patient = patientService.AddPatient(firstName, lastName, birthDay, phone, diagnosis);
				await Clients.Caller.SendAsync("AddPatientValid", patient);
			}
		}
	}
}
