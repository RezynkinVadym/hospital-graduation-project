using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
	internal class Patient
	{
		public int ID { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public DateTime DateOfBirth { get; private set; }
		public string Phone { get; private set; }
		public string Diagnosis { get; private set; }

		public Patient(int id, string firstName, string lastName, DateTime birthDay, string phone, string diagnosis)
		{
			ID = id;
			FirstName = firstName;
			LastName = lastName;
			DateOfBirth = birthDay;
			Phone = phone;
			Diagnosis = diagnosis;
		}
	}
}
