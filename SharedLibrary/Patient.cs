using System;

namespace SharedLibrary
{
	public class Patient
	{
		public long ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDay { get; set; }
		public string Phone { get; set; }
		public string Diagnosis { get; set; }

		public Patient(string firstName, string lastName, DateTime birthDay, string phone, string diagnosis)
		{
			FirstName = firstName;
			LastName = lastName;
			BirthDay = birthDay;
			Phone = phone;
			Diagnosis = diagnosis;
		}
		public Patient(long id, string firstName, string lastName, DateTime birthDay, string phone, string diagnosis)
		{
			ID = id;
			FirstName = firstName;
			LastName = lastName;
			BirthDay = birthDay;
			Phone = phone;
			Diagnosis = diagnosis;
		}

		public Patient(){}

	}
}
