using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entities
{
	public class User
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		private char sex;
		public char Sex
		{
			get { return sex; }
			set
			{
				if (value == 'M' || value == 'W')
					sex = value;
				else
					throw new ArgumentException();
			}
		}
		public DateTime BirthDay { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public User(string firstName, string lastName, string email, char sex, DateTime birthDay, string login, string password) {
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Sex = sex;
			BirthDay = birthDay;
			Login = login;
			Password = password;
		}
	}
}
