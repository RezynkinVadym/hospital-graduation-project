using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Validation
{
	public partial class StringValidation
	{
		public bool Diagnosis(string diagnosis)
		{
			if (diagnosis.Equals(string.Empty))
			{
				ErrorText = "Діагноз є обов'язковим для заповнення";
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
