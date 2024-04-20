using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
	abstract internal class AccountData
	{
		public static string GetLogin{ get; private set; }
		public static string GetName { get; private set; }
		public static string GetSurname { get; private set;}
		public static string GetMail { get; private set; }
		public static DateTime GetDateOfBirth { get; private set; }
		public static char GetSex { get; private set;}
		static Thread thread;
		public static void InitializeData(string accountData)
		{
			string[] data = accountData.Split(';');
			GetLogin = data[0];
			GetName = data[1];
			GetSurname = data[2];
			GetMail = data[3];
			GetDateOfBirth = DateTime.Parse(data[4]);
			GetSex = Char.Parse(data[5]);
		}
		public static void EditData(string name, string surname, string mail, DateTime dateOfBirth, char sex)
		{
			GetName = name;
			GetSurname = surname;
			GetMail = mail;
			GetDateOfBirth = dateOfBirth;
			GetSex = sex;
			thread = new Thread(NetworkClient.SendQuery);
			thread.Start("edit;" + GetLogin + ";" + name + ";" + surname + ";" + mail + ";" + dateOfBirth + ";" + sex);
			new Thread(ThreadTracking).Start();
		}
		static void ThreadTracking()
		{
			thread.Join();
			if (NetworkClient.Result == "Помилка")
				MessageBox.Show("Зміни при редагуванні не були внесені до бази даних, спробуйте ще раз", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				MessageBox.Show("Зміни були внесені", "Редагування", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

	}
}
