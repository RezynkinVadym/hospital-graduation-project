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
		public bool LastName(string lastName)
		{
			if (lastName.Equals(string.Empty))
			{
				ErrorText = "Прізвище є обов'язковим для заповнення";
				return false;
			}
			if (lastName.Length < 2)
			{
				ErrorText = "Прізвище не може складатись з однієї літери";
				return false;
			}
			if (lastName.Length > 20)
			{
				ErrorText = "Прізвище не може складатись більше ніж 20 літер";
				return false;
			}
			if (Regex.IsMatch(lastName, @"\P{IsCyrillic}"))
			{
				ErrorText = "В прізвищі мають бути лише символи кирилиці";
				return false;
			}
			return true;
		}
	}
}
