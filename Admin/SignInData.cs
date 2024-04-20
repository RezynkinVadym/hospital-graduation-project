using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Admin
{
	abstract internal class SignInData
	{
		static Thread thread;
		static FormAuthorization callingForm;

		public static void SignIn(string login, string password, FormAuthorization form)
		{

			thread = new Thread(NetworkClient.SendQuery);
			thread.Start("signIn;" + login + ";" + password);
			callingForm = form;
			new Thread(ThreadTracking).Start();
		}
		static void ThreadTracking()
		{
			thread.Join();
			callingForm.SignInComplete(NetworkClient.Result);
		}
	}
}
