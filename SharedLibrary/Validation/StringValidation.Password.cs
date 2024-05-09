using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLibrary.Validation
{
	public partial class StringValidation
	{
		public bool Password(string password)
		{
			if (password.Equals(string.Empty))
			{
				ErrorText = "Пароль є обов'язковим для заповнення";
				return false;
			}
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
	}
}
