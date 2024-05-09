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
using Microsoft.AspNetCore.SignalR.Client;
using SharedLibrary.Validation;

namespace Admin
{
	public partial class FormConfirmRegistration : Form
	{
		FormRegistration formFirstRegistration;
		FormAuthorization authorization;
		FormLoading formLoading;
		StringValidation validation;
		public FormConfirmRegistration(FormRegistration formRegistration, FormAuthorization formAuthorization)
		{
			InitializeComponent();
			validation = new StringValidation();
			formFirstRegistration = formRegistration;
			authorization = formAuthorization;
			textBoxPassword.UseSystemPasswordChar = true;
			formLoading = new FormLoading();
			formLoading.StartPosition = FormStartPosition.CenterParent;
			HubConnect.On<string>("RegistrationInvalidLogin", (message) =>
			{
				Invoke((MethodInvoker)delegate
				{
					formLoading.Close();
					labelLoginError.Text = message;
				});
			});
			HubConnect.On<string>("RegistrationInvalidPassword", (message) =>
			{
				Invoke((MethodInvoker)delegate
				{
					formLoading.Close();
					labelPasswordError.Text = message;
				});
			});
			HubConnect.On<string>("SecondRegistrationValid", (message) =>
			{
				if(message.Equals("Зареєстровано"))
					Invoke((MethodInvoker)delegate
					{
						formLoading.Close();
						formFirstRegistration.Close();
						authorization.RegistrationComplete(textBoxLogin.Text, textBoxPassword.Text);
						Close();
					});
				else if(message.Equals("Цей логін вже зайнятий"))
				{
					Invoke((MethodInvoker)delegate
					{
						formLoading.Close();
					});
					MessageBox.Show("Вказаний логін вже існує", "Неможливо зареєструвати", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			});
		}

		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			labelPasswordError.Text = string.Empty;
			labelLoginError.Text = string.Empty;
			string passwordText = textBoxPassword.Text;
			string loginText = textBoxLogin.Text;
			bool successRegistration = true;
			if (!validation.Login(loginText))
			{
				successRegistration = false;
				labelLoginError.Text = validation.ErrorText;
			}
			if (!validation.Password(passwordText))
			{
				successRegistration = false;
				labelPasswordError.Text = validation.ErrorText;
			}
			if (successRegistration)
			{
				Task.Run(async () => await Registration(HubConnect.GetConnection(), loginText, passwordText));
				formLoading.ShowDialog();
			}
		}

		private static async Task Registration(HubConnection connection, string login, string password)
		{
			try
			{
				await connection.InvokeAsync("SecondStepRegistration", login, password);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		private void buttonBack_Click(object sender, EventArgs e)
		{
			Close();
			formFirstRegistration.Visible = true;
		}
		private void FormConfirmRegistration_FormClosing(object sender, FormClosingEventArgs e)
		{
			HubConnect.Off("RegistrationInvalidLogin");
			HubConnect.Off("RegistrationInvalidPassword");
			HubConnect.Off("SecondRegistrationValid");
		}
	}
}
