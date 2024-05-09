using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Validation
{
	public partial class StringValidation
	{
		public bool Login(string login)
		{
			if (login.Equals(string.Empty))
			{
				ErrorText = "Логін є обов'язковим для заповнення";
			}
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
					ErrorText = "Логін складається лише з цифр та латинських літер";
					return false;
				}
			}
			return true;
		}
	}
}
