using Microsoft.AspNetCore.SignalR;
using SharedLibrary;
using Server.Infrastructure;
using Server.Services;

namespace Service.Hubs
{
	public partial class ServiceHub
	{
		public async Task EditPatient(long id, string firstName, string lastName, DateTime birthDay, string phone, string diagnosis)
		{
			if (!validation.Diagnosis(diagnosis) || !validation.Phone(phone) || !validation.LastName(lastName) || !validation.FirstName(firstName))
			{
				await Clients.Caller.SendAsync("EditPatientInvalid", validation.ErrorText);
			}
			else
			{
				PatientRepository patientRepository = new();
				PatientService patientService = new(patientRepository);
				Patient patient = new Patient(id, firstName, lastName, birthDay, phone, diagnosis);
				patientService.EditPatient(patient);
				await Clients.Caller.SendAsync("EditPatientValid", patient);
			}
		}
	}
}

