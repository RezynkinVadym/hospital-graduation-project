using Server.Entities;
using Server.Interfaces;
using SharedLibrary;

namespace Server.Services
{
	public class PatientService
	{
		private readonly IRepositoryPatient<Patient> patientRepository;
		public PatientService(IRepositoryPatient<Patient> patientRepository)
		{
			this.patientRepository = patientRepository;
		}
		public Patient AddPatient(string firstName, string lastName, DateTime birthDay, string phone, string diagnosis)
		{
			Patient patient = patientRepository.Add(new Patient(firstName, lastName, birthDay, phone, diagnosis));
			return patient;
		}
		public void DeletePatient(long id)
		{
			patientRepository.Delete(id);
		}
		public List<Patient> GetAllPatients()
		{
			return patientRepository.GetAll();
		}
		public void EditPatient(Patient patient)
		{
			patientRepository.Update(patient);
		}
	}
}
