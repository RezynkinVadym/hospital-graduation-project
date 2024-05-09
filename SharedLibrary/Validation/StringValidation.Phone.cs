using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Validation
{
	public partial class StringValidation
	{
		public bool Phone(string phone)
		{
			if (phone.Equals(string.Empty))
			{
				ErrorText = "Номер телефону є обов'язковим для заповнення";
				return false;
			}
			else if (phone.Length != 10)
			{
				ErrorText = "Неправильна кількість цифр номеру телефону";
				return false;
			}
			return true;
		}
	}
}
