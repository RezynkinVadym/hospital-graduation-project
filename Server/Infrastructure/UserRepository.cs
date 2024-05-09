using MySql.Data.MySqlClient;
using Server.Entities;
using Server.Interfaces;
using System.Data.Common;

namespace Server.Infrastructure
{
	public class UserRepository : IRepositoryUser<User>
	{
		private readonly DBConnection conn = new();
		public void Add(User user)//додавання в бд нового користувача
		{
			MySqlCommand command = new ("INSERT INTO `users` (`first_name`, `last_name`, `email`, `birth_day`, `sex`, `login`, `password`) "
			+ "VALUES (@fN, @lN, @e, @bD, @s, @l, @p)", conn.GetConnection());
			command.Parameters.Add("@fN", MySqlDbType.VarChar).Value = user.FirstName;
			command.Parameters.Add("@lN", MySqlDbType.VarChar).Value = user.LastName;
			command.Parameters.Add("@e", MySqlDbType.VarChar).Value = user.Email;
			command.Parameters.Add("@bD", MySqlDbType.Date).Value = user.BirthDay;
			command.Parameters.Add("@s", MySqlDbType.String).Value = user.Sex;
			command.Parameters.Add("@l", MySqlDbType.VarChar).Value = user.Login;
			command.Parameters.Add("@p", MySqlDbType.VarChar).Value = user.Password;
			command.ExecuteNonQuery();
		}
		public User GetByLogin(string login)//знаходить користувача по логіну
		{
			MySqlCommand command = new ("SELECT * FROM `users` WHERE `login` = @l", conn.GetConnection());
			command.Parameters.Add("@l", MySqlDbType.VarChar).Value = login;
			using DbDataReader reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				reader.Read();
				string password = reader.GetString(7);
				string firstName = reader.GetString(1);
				string lastName = reader.GetString(2);
				string email = reader.GetString(3);
				DateTime birthDay = reader.GetDateTime(4);
				char sex = reader.GetChar(5);
				return new User(firstName, lastName, email, sex, birthDay, login, password);
			}
			else
				return null;
		}
		public void Update(User user)//редагування даних про користувача за його логіном
		{
			MySqlCommand command = new ("UPDATE `users` SET `first_name` = @fN, `last_name` = @lN," +
				" `email` = @e, `birth_day` = @bD, `sex` = @s" + " WHERE `login` = @l", conn.GetConnection());
			command.Parameters.Add("@l", MySqlDbType.VarChar).Value = user.Login;
			command.Parameters.Add("@fN", MySqlDbType.VarChar).Value = user.FirstName;
			command.Parameters.Add("@lN", MySqlDbType.VarChar).Value = user.LastName;
			command.Parameters.Add("@e", MySqlDbType.VarChar).Value = user.Email;
			command.Parameters.Add("@bD", MySqlDbType.Date).Value = user.BirthDay;
			command.Parameters.Add("@s", MySqlDbType.String).Value = user.Sex;
			command.ExecuteNonQuery();
		}

		void IRepositoryUser<User>.Delete(User entity)
		{
			throw new NotImplementedException();
		}
	}
}
