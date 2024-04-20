using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Admin
{
	abstract internal class RegistrationData
	{
		static string firstName;
		static string lastName;
		static string email;
		static char sex;
		static DateTime dateOfBirth;
		static string login, password;
		static Thread thread;
		static FormConfirmRegistration callingForm;

		public static void RegistrationComplete(string name, string surname, string mail, char sex, DateTime date)
		{
			firstName = name;
			lastName = surname;
			email = mail;
			RegistrationData.sex = sex;
			dateOfBirth = date;
		}
		public static void RegistrationConfirmComplete(string login, string password, FormConfirmRegistration form)
		{
			RegistrationData.password = password;
			RegistrationData.login = login;
			thread = new Thread(NetworkClient.SendQuery);
			thread.Start("registration;" + firstName + ";" + lastName + ";" + email + ";" + dateOfBirth.ToString() + ";" + sex + ";" + login + ";" + password);
			callingForm = form;
			new Thread(ThreadTracking).Start();
		}
		static void ThreadTracking()
		{
			thread.Join();
			callingForm.RegistrationComplete(login, password);
		}
	}
}
