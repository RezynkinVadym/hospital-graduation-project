using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics.Eventing.Reader;

namespace Admin
{
	public partial class FormConfirmRegistration : Form
	{
		FormRegistration form;
		FormAuthorization authorization;
		FormLoading formLoad;
		public FormConfirmRegistration(FormRegistration formRegistration, FormAuthorization formAuthorization)
		{
			InitializeComponent();
			form = formRegistration;
			authorization = formAuthorization;
			textBoxPassword.UseSystemPasswordChar = true;
		}

		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			labelPasswordError.Text = string.Empty;
			labelLoginError.Text = string.Empty;
			string passwordText = textBoxPassword.Text;
			string loginText = textBoxLogin.Text;
			bool successRegistration = true;
			if (!AuthorizationCheck.CheckLogin(loginText))
			{
				successRegistration = false;
				labelLoginError.Text = AuthorizationCheck.ErrorText;
			}
			if (!AuthorizationCheck.CheckPassword(passwordText))
			{
				successRegistration = false;
				labelPasswordError.Text = AuthorizationCheck.ErrorText;
			}
			if (successRegistration)
			{
				RegistrationData.RegistrationConfirmComplete(loginText, passwordText, this);
				formLoad = new FormLoading();
				formLoad.StartPosition = FormStartPosition.CenterParent;
				formLoad.ShowDialog();
			}
		}

		public void RegistrationComplete(string login, string password)
		{
			Invoke((MethodInvoker)delegate
			{
				formLoad.Close();
			});
			string registrationResult = NetworkClient.Result;
			MessageBox.Show(registrationResult);
			if (registrationResult == "Успішно зареєстровано")
			{
				Invoke((MethodInvoker)delegate
				{
					this.Close();
					form.Close();
					authorization.RegistrationComplete(login, password);
				});
			}
		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			form.Show();
			this.Close();
		}
	}
}
