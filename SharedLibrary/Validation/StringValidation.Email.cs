using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharedLibrary.Validation
{
	public partial class StringValidation
	{
		public bool Email(string email)
		{
			if (email.Equals(string.Empty))
			{
				ErrorText = "Пошта є обов'язковою для заповнення";
				return false;
			}
			if (!Regex.IsMatch(email, @"^[-\w.]+@([A-Za-z0-9][-A-Za-z0-9]+\.)+[A-Za-z]{2,4}$"))//регулярний вираз, якому має відповідати поштовий адрес
			{
				ErrorText = "Неправильний формат пошти";
				return false;
			}
			return true;
		}
	}
}
