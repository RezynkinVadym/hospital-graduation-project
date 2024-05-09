using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Entities;

namespace Server.Services
{
	public class UserService
	{
		private readonly IRepositoryUser<User> userRepository;
		public UserService(IRepositoryUser<User> userRepository)
		{
			this.userRepository = userRepository;
		}
		public string RegisterUser(string ID, string login, string password)
		{
			User user = userRepository.GetByLogin(login);
			if (user != null) {
				return "Цей логін вже зайнятий";
			}
			DTOFirstStepRegistration userData = DataFirstStepRegistration.GetUserDataByID(ID);//збережені дані з першого кроку реєстрації
			if(userData == null)
			{
				throw new NotImplementedException();
			}
			user = new(userData.FirstName, userData.LastName, userData.Email, userData.Sex, userData.DateOfBirth, login, password);
			userRepository.Add(user);
			DataFirstStepRegistration.ClearUserDataByID(ID);//користувач пройшов реєстрацію, дані про перший крок треба видалити
			return "Зареєстровано";
		}
		public User SignIn(string login, string password)
		{
			User user = userRepository.GetByLogin(login);
			if (user == null)
				return null;
			if(password != user.Password)
			{
				return null;
			}
			return user;
		}
		public string EditAccount(string firstName, string lastName, string email, char sex, DateTime birthDay, string login)
		{
			User user = userRepository.GetByLogin(login);
			if (user == null)
				return "Такого користувача не існує";
			user = new(firstName, lastName, email, sex, birthDay, login, "");//створюється користувач без паролю, оскільки пароль при редагуванні не змінюється
			userRepository.Update(user);
			return "Відредаговано";
		}
	}
}
