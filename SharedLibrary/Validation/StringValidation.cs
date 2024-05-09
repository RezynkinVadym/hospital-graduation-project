using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Validation
{
	public partial class StringValidation
	{
		public StringValidation()
		{
			ErrorText = string.Empty;
		}
		public string ErrorText { get; protected set; }
	}
}
