using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Admin
{
	abstract internal class AuthorizationCheck
	{
		static public string ErrorText { get; set; }
		static public bool CheckLogin(string login)//усі методи повертають true, якщо дані введені без помилок
		{
			if (login.Length < 4 || login.Length > 12)
			{
				ErrorText = "Логін має бути від 4 до 12 символів";
				return false;
			}
			else if (Char.IsDigit(login[0]))
			{
				ErrorText = "Цифра не може бути першим символом логіну";
				return false;
			}
			for (int i = 0; i < login.Length; i++)
			{
				if (!(Char.IsDigit(login[i]) || login[i] >= 'a' && login[i] <= 'z' || login[i] >= 'A' && login[i] <= 'Z'))
				{
					ErrorText = "Лише цифри та латинські літери!";
					return false;
				}
			}
			return true;
		}
		static public bool CheckPassword(string password)
		{
			if (password.Length < 8 || password.Length > 25)
			{
				ErrorText = "Пароль має бути від 8 до 25 символів";
				return false;
			}
			if (password.Contains(" ") || password.Contains(";"))
			{
				ErrorText = "Пароль не має містити символів \" \" чи \";\"";
				return false;
			}
			var cyrillic = Enumerable.Range(1024, 256).Select(ch => (char)ch);
			if (password.Any(cyrillic.Contains))
			{
				ErrorText = "Пароль не має містити символів кирилиці";
				return false;
			}
			return true;
		}
		
		static public bool CheckName(string name)
		{
			if(name == string.Empty)
			{
				ErrorText = "Поле є обов'язковим для введення";
				return false;
			}
			if(name.Length < 2)
			{
				ErrorText = "Не може складатись з однієї літери";
				return false;
			}
			if(name.Length > 20)
			{
				ErrorText = "Не може складатись з більше 20 літер";
				return false;
			}
			if (Regex.IsMatch(name, @"\P{IsCyrillic}")){
				ErrorText = "Тут мають бути лише символи кирилиці";
				return false;
			}
			return true;
		}
		static public bool CheckEmail(string mail)
		{
			if (mail == string.Empty)
			{
				ErrorText = "Поле є обов'язковим для введення";
				return false;
			}
			if (!Regex.IsMatch(mail, @"^[-\w.]+@([A-Za-z0-9][-A-Za-z0-9]+\.)+[A-Za-z]{2,4}$"))//регулярний вираз, якому має відповідати поштовий адрес
			{
				ErrorText = "Неправильно вказана пошта";
				return false;
			}
			return true;
		}
		static public bool CheckPhone(string phone)
		{
			if (phone == string.Empty)
			{
				ErrorText = "Поле є обов'язковим для введення";
				return false;
			}
			else if(phone.Length != 10) {
				ErrorText = "Неправильна кількість цифр номеру телефону";
				return false;
			}
			return true;
		}
		static public bool CheckDiagnosis(string diagnosis)
		{
			if (diagnosis == string.Empty)
			{
				ErrorText = "Поле є обов'язковим для введення";
				return false;
			}
			else if (diagnosis.Length < 5 || diagnosis.Length > 100)
			{
				ErrorText = "Діагноз не може бути менше 5 чи більше 100 символів";
				return false;
			}
			return true;
		}
	}
}
