using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
	internal class PatientList
	{
		BindingList<Patient> listOfPatients = new BindingList<Patient>();
		BindingSource bindingSource;
		Thread thread;
		string[] arrDataQuery;
		FormPatientsList callingForm;
		public PatientList()
		{
			bindingSource = new BindingSource { DataSource = listOfPatients };
		}
		public BindingSource GetBindingSource()
		{
			return bindingSource;
		}
		public void SendQuery(string patientDataQuery, FormPatientsList form)
		{
			callingForm = form;
			thread = new Thread(NetworkClient.SendQuery);
			thread.Start(patientDataQuery);
			arrDataQuery = patientDataQuery.Split(';');
			if (arrDataQuery[1] == "add")
				new Thread(AddNewPatient).Start();
			else if (arrDataQuery[1] == "edit")
				new Thread(DeleteOrEditPatient).Start("edit");
			else if (arrDataQuery[1] == "delete")
				new Thread(DeleteOrEditPatient).Start("delete");

			

		}
		public BindingSource GetAllPatients()
		{
			string result = NetworkClient.GetAllPatients("patient;get");
			if (result != "none")
			{
				string[] dataPatient = result.Split(';');
				string name = "", surname = "", phone = "", diagnosis = "";
				int id = 0;
				DateTime birth = DateTime.Now;
				for (int i = 0; i < dataPatient.Length; i++)
				{
					int fieldNumber = i % 6;//6, оскільки в класі Пацієнт лише 6 полів і в рядку що повертає БД вони йдуть циклічно
					switch (fieldNumber)
					{
						case 0: id = Int32.Parse(dataPatient[i]); break;
						case 1: name = dataPatient[i]; break;
						case 2: surname = dataPatient[i]; break;
						case 3: birth = DateTime.Parse(dataPatient[i]); break;
						case 4: phone = dataPatient[i]; break;
						case 5: diagnosis = dataPatient[i]; bindingSource.Add(new Patient(id, name, surname, birth, phone, diagnosis)); break;

					}
				}
			}
			return bindingSource;
		}
		void AddNewPatient()
		{
			thread.Join();
			if (NetworkClient.Result != "Сталась помилка, спробуйте пізніше")
			{
				callingForm.AddComplete(new Patient(Int32.Parse(NetworkClient.Result), arrDataQuery[2], arrDataQuery[3], DateTime.Parse(arrDataQuery[4]), arrDataQuery[5], arrDataQuery[6]), bindingSource);
			}
		}
		void DeleteOrEditPatient(object target)
		{
			string targ = (string)target;
			int id;
			thread.Join();
			if (Int32.TryParse(NetworkClient.Result, out id))
			{
				int index = 0;
				for (int i = 0; i < bindingSource.Count; i++)//пошук індекса в списку якому відповідає такий id
				{
					Patient patient = (Patient)bindingSource[i];
					if (patient.ID == id)
					{
						index = i;
						break;
					}
				}
				if (targ == "delete")
					callingForm.DeleteComplete(bindingSource, index);
				else
					callingForm.EditComplete(bindingSource, index);
			}
			else
				MessageBox.Show(NetworkClient.Result, "Error occured", MessageBoxButtons.OK);
		}
	}
}
