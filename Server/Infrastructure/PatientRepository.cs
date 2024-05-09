using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SharedLibrary;
using Server.Interfaces;

namespace Server.Infrastructure
{
	public class PatientRepository : IRepositoryPatient<Patient>
	{
		DBConnection conn = new();
		Patient IRepositoryPatient<Patient>.Add(Patient patient)
		{
			MySqlCommand command = new ("INSERT INTO `patients` (`first_name`, `last_name`, `birth_day`, `phone`, `diagnosis`) "
			+ "VALUES (@fN, @lN, @bD, @p, @d)", conn.GetConnection());
			command.Parameters.Add("@fN", MySqlDbType.VarChar).Value = patient.FirstName;
			command.Parameters.Add("@lN", MySqlDbType.VarChar).Value = patient.LastName;
			command.Parameters.Add("@bD", MySqlDbType.Date).Value = patient.BirthDay;
			command.Parameters.Add("@p", MySqlDbType.VarChar).Value = patient.Phone;
			command.Parameters.Add("@d", MySqlDbType.VarChar).Value = patient.Diagnosis;
			command.ExecuteNonQuery();
			long id = command.LastInsertedId;
			patient.ID = id;
			return patient;
		}

		void IRepositoryPatient<Patient>.Delete(long id)
		{
			MySqlCommand command = new ("DELETE FROM `patients` WHERE `patient_id` = @id", conn.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
			command.ExecuteNonQuery();
		}

		List<Patient> IRepositoryPatient<Patient>.GetAll()
		{
			MySqlCommand command = new ("SELECT * FROM `patients`", conn.GetConnection());
			MySqlDataAdapter adapter = new();
			adapter.SelectCommand = command;
			DataTable table = new(); 
			adapter.Fill(table);
			List<Patient> patients = new();
			for (int i = 0; i < table.Rows.Count; i++)
			{
				long id = long.Parse(table.Rows[i]["patient_id"].ToString());
				string name = table.Rows[i]["first_name"].ToString();
				string lastName = table.Rows[i]["last_name"].ToString();
				DateTime birthDay = DateTime.Parse(table.Rows[i]["birth_day"].ToString());
				string phone = table.Rows[i]["phone"].ToString();
				string diagnosis = table.Rows[i]["diagnosis"].ToString();
				Patient patient = new Patient(id, name, lastName, birthDay, phone, diagnosis);
				patients.Add(patient);
			}
			return patients;
		}

		Patient IRepositoryPatient<Patient>.GetByID(long id)
		{
			throw new NotImplementedException();
		}

		void IRepositoryPatient<Patient>.Update(Patient patient)
		{
			MySqlCommand command = new ("UPDATE `patients` SET `first_name` = @fN, `last_name` = @lN, `birth_day` = @bD, `phone` = @p, `diagnosis` = @d "
			+ "WHERE `patient_id` = @id", conn.GetConnection());
			command.Parameters.Add("@fN", MySqlDbType.VarChar).Value = patient.FirstName;
			command.Parameters.Add("@lN", MySqlDbType.VarChar).Value = patient.LastName;
			command.Parameters.Add("@bD", MySqlDbType.Date).Value = patient.BirthDay;
			command.Parameters.Add("@p", MySqlDbType.VarChar).Value = patient.Phone;
			command.Parameters.Add("@d", MySqlDbType.VarChar).Value = patient.Diagnosis;
			command.Parameters.Add("@id", MySqlDbType.Int32).Value = patient.ID;
			command.ExecuteNonQuery();
		}
	}
}
