using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Server
{
	internal class DBQuery // запити до бази даних
	{
		DBConnection conn = new DBConnection();
		DataTable table = new DataTable();
		MySqlDataAdapter adapter = new MySqlDataAdapter();
		MySqlCommand command;

		public string Registration(string name, string surname, string mail, DateTime birth, char sex, string login, string password)//додавання в бд нового користувача
		{
			command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", conn.GetConnection());
			command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
			adapter.SelectCommand = command;
			adapter.Fill(table);
			if (table.Rows.Count > 0)
				return "Цей логін вже зайнятий";
			else
			{
				command = new MySqlCommand("INSERT INTO `users` (`Firstname`, `Lastname`, `Email`, `DateOfBirth`, `Sex`, `Login`, `Password`) "
				+ "VALUES (@fN, @lN, @e, @dB, @s, @l, @p)", conn.GetConnection());
				command.Parameters.Add("@fN", MySqlDbType.VarChar).Value = name;
				command.Parameters.Add("@lN", MySqlDbType.VarChar).Value = surname;
				command.Parameters.Add("@e", MySqlDbType.VarChar).Value = mail;
				command.Parameters.Add("@dB", MySqlDbType.Date).Value = birth;
				command.Parameters.Add("@s", MySqlDbType.String).Value = sex;
				command.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;
				command.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;

				if(command.ExecuteNonQuery() == 1)
				{
					return "Успішно зареєстровано";
				}
				return "Сталась помилка, спробуйте пізніше";
			}
		}
		public string SignIn(string login, string password)//вхід користувача по його логіну та паролю, необхідно повернути інформацію про акаунт
		{
			command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", conn.GetConnection());
			command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
			using (DbDataReader reader = command.ExecuteReader())
			{
				if (reader.HasRows)
				{
					reader.Read();
					string readedPass = reader.GetString(7);
					if (readedPass == password)
					{
						string firstName = reader.GetString(1);
						string lastName = reader.GetString(2);
						string email = reader.GetString(3);
						string dateString = reader.GetDateTime(4).ToString();
						char sex = reader.GetChar(5);

						return login + ';' + firstName + ';' + lastName + ';' + email + ';' + dateString + ";" + sex;
					}
					else
						return "Неправильний пароль";
				}
				else
					return "Немає користувача з цим логіном";
			}
		}
		public string Edit(string login,  string firstName, string lastName, string email, DateTime birth, char sex)//редагування даних про профіль користувача
		{
			command = new MySqlCommand("UPDATE `users` SET `Firstname` = @fn, `Lastname` = @ln," +
				" `Email` = @e, `DateOfBirth` = @db, `Sex` = @s" + " WHERE `login` = @uL", conn.GetConnection());
			command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
			command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = firstName;
			command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastName;
			command.Parameters.Add("@e", MySqlDbType.VarChar).Value = email;
			command.Parameters.Add("@db", MySqlDbType.Date).Value = birth;
			command.Parameters.Add("@s", MySqlDbType.String).Value = sex;
			int affectedRows = command.ExecuteNonQuery();
			if (affectedRows > 0)
			{
				return "Успішно відредаговано";
			}
			else
				return "Помилка";
		}
		public string AddPatient(string firstName, string lastName, DateTime birth, string phone, string diagnosis)//додавання в БД нового пацієнта та повернення його ID та інших даних
		{
			command = new MySqlCommand("INSERT INTO `patients` (`Firstname`, `Lastname`, `DateOfBirth`, `Phone`, `Diagnosis`) "
			+ "VALUES (@fN, @lN, @dB, @P, @D)", conn.GetConnection());
			command.Parameters.Add("@fN", MySqlDbType.VarChar).Value = firstName;
			command.Parameters.Add("@lN", MySqlDbType.VarChar).Value = lastName;
			command.Parameters.Add("@dB", MySqlDbType.Date).Value = birth;
			command.Parameters.Add("@P", MySqlDbType.VarChar).Value = phone;
			command.Parameters.Add("@D", MySqlDbType.VarChar).Value = diagnosis;
			command.ExecuteNonQuery();
			long id = command.LastInsertedId;
			if (id != -1)
			{
				return id.ToString();
			}
			return "Сталась помилка, спробуйте пізніше";
		}
		public string GetAllPatients()//повертає всіх пацієнтів з бази даних у вигляді рядкової змінної
		{
			command = new MySqlCommand("SELECT * FROM `patients`", conn.GetConnection());
			adapter.SelectCommand = command;
			adapter.Fill(table);
			string result = "";
			for(int i = 0; i < table.Rows.Count; i++)
			{
				for(int j = 0; j < table.Columns.Count; j++)
				{
					result += table.Rows[i][j].ToString();
					result += ";";
				}
			}
			result = result.TrimEnd(';');
			if(result != "")
				return result;
			return "none";
		}
		public string DeletePatient(int id)//видалення пацієнта за його ID та інших даних
		{
			command = new MySqlCommand("DELETE FROM `patients` WHERE `Id` = @id", conn.GetConnection());
			command.Parameters.Add("@id", MySqlDbType.Int64).Value = id;
			int affectedRows = command.ExecuteNonQuery();
			if (affectedRows == 1)
			{
				return id.ToString();
			}
			return "Сталась помилка, спробуйте пізніше";
		}
		public string EditPatient(int idToEdit, string firstName, string lastName, DateTime birth, string phone, string diagnosis)//додавання в БД нового пацієнта та повернення його ID та інших даних
		{
			// "UPDATE Inventory SET Inventorynumber='"+ num +"',Inventory_Name='"+name+"', Quantity ='"+ quant+"',Location ='"+ location+"' Category ='"+ category+"' WHERE Inventorynumber ='"+ numquery +"';";
			command = new MySqlCommand("UPDATE `patients` SET `Firstname` = @fN, `Lastname` = @lN, `DateOfBirth` = @db, `Phone` = @P, `Diagnosis` = @D "
			+ "WHERE `Id` = @id", conn.GetConnection());
			command.Parameters.Add("@fN", MySqlDbType.VarChar).Value = firstName;
			command.Parameters.Add("@lN", MySqlDbType.VarChar).Value = lastName;
			command.Parameters.Add("@dB", MySqlDbType.Date).Value = birth;
			command.Parameters.Add("@P", MySqlDbType.VarChar).Value = phone;
			command.Parameters.Add("@D", MySqlDbType.VarChar).Value = diagnosis;
			command.Parameters.Add("@id", MySqlDbType.Int32).Value = idToEdit;
			int affectedRows = command.ExecuteNonQuery();
			if (affectedRows == 1)
			{
				return idToEdit.ToString();
			}
			return "Сталась помилка, спробуйте пізніше";
		}
	}
}
