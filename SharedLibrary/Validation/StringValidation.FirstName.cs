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
		public bool FirstName(string name)
		{
			if (name.Equals(string.Empty))
			{
				ErrorText = "Ім'я є обов'язковим для заповнення";
				return false;
			}
			if (name.Length < 2)
			{
				ErrorText = "Ім'я не може складатись з однієї літери";
				return false;
			}
			if (name.Length > 20)
			{
				ErrorText = "Ім'я не може складатись більше ніж 20 літер";
				return false;
			}
			if (Regex.IsMatch(name, @"\P{IsCyrillic}"))
			{
				ErrorText = "В імені мають бути лише символи кирилиці";
				return false;
			}
			return true;
		}
	}
}
