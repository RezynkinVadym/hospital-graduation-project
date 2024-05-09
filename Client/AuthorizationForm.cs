using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary.Validation;

namespace Admin
{
	public partial class FormAuthorization : Form
	{
		string loginHint = "Введіть ваш логін";
		string passwordHint = "Введіть ваш пароль";
		FormLoading formLoading;
		StringValidation validation;
		public FormAuthorization(){
			Task.Run(async () => await HubConnect.Connect()).Wait();
			InitializeComponent();
			validation = new StringValidation();
			formLoading = new FormLoading();
			formLoading.StartPosition = FormStartPosition.CenterParent;
			NeedAHint(textBoxLogin, loginHint);
			NeedAHint(textBoxPassword, passwordHint);
			HubConnect.On<string>("SignInInvalidLogin", (message) =>
			{
				Invoke((MethodInvoker)delegate
				{
					formLoading.Close();
					labelLoginError.Text = message;
				});
			});
			HubConnect.On<string>("SignInInvalidPassword", (message) =>
			{
				Invoke((MethodInvoker)delegate
				{
					formLoading.Close();
					labelPasswordError.Text = message;
				});
			});
			HubConnect.On<object>("SignInIncorrectData", (none) =>
			{
				Invoke((MethodInvoker)delegate
				{
					formLoading.Close();
					MessageBox.Show("Неправильний логін чи пароль", "Неправильні дані", MessageBoxButtons.OK, MessageBoxIcon.Information);
				});
			});
			HubConnect.On<string, string, string, char, DateTime, string>("SignInValid", 
			(firstName, lastName, email, sex, birthDay, login) =>
			{
				Invoke((MethodInvoker)delegate
				{
					formLoading.Close();
					Visible = false;
					new FormAccount(this, firstName, lastName, email, sex, birthDay, login).Show();
				});
			});
		}
		void NeedAHint(TextBox textBox, string text)
		{
			textBox.Text = text;
			textBox.ForeColor = Color.Gray;
		}
		private void textBoxLogin_Click(object sender, EventArgs e)
		{
			string loginText = textBoxLogin.Text;
			if (loginText == loginHint)
			{
				textBoxLogin.Text = string.Empty;
				textBoxLogin.ForeColor = Color.Black;
			}
		}
		private void textBoxLogin_Leave(object sender, EventArgs e)
		{
			if (textBoxLogin.TextLength == 0)
				NeedAHint(textBoxLogin, loginHint);
		}
		private void textBoxPassword_Click(object sender, EventArgs e)
		{
			textBoxPassword.UseSystemPasswordChar = true;
			string passwordText = textBoxPassword.Text;
			if (passwordText == passwordHint)
			{
				textBoxPassword.Text = string.Empty;
				textBoxPassword.ForeColor = Color.Black;
			}
		}
		private void textBoxPassword_Leave(object sender, EventArgs e)
		{
			if (textBoxPassword.TextLength == 0)
			{
				NeedAHint(textBoxPassword, passwordHint);
				textBoxPassword.UseSystemPasswordChar = false;
			}
		}

		private void buttonSignIn_Click(object sender, EventArgs e)
		{
			labelPasswordError.Text = string.Empty;
			labelLoginError.Text = string.Empty;
			string passwordText = textBoxPassword.Text;
			string loginText = textBoxLogin.Text;
			bool successSignIn = true;
			if (!validation.Login(loginText)) { 
				
				successSignIn = false;
				labelLoginError.Text = validation.ErrorText;
			}
			if (!validation.Password(passwordText))
			{
				successSignIn = false;
				labelPasswordError.Text = validation.ErrorText;
			}
			if (successSignIn)
			{
				Task.Run(async () => await SignIn(HubConnect.GetConnection(), loginText, passwordText));
				formLoading.ShowDialog();
			}
		}
		private static async Task SignIn(HubConnection connection, string login, string password)
		{
			try
			{
				await connection.InvokeAsync("SignIn", login, password);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		private void buttonSignUp_Click(object sender, EventArgs e)
		{
			FormRegistration form = new FormRegistration(this);
			form.Show();
			Visible = false;
		}
		public void RegistrationComplete(string login, string password)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)delegate
				{
					Show();
					textBoxLogin.Text = login;
					textBoxLogin.ForeColor = Color.Black;
					textBoxPassword.Text = password;
					textBoxPassword.ForeColor = Color.Black;
					textBoxPassword.UseSystemPasswordChar = true;
				});
			}
			else
			{
				Show();
				textBoxLogin.Text = login;
				textBoxLogin.ForeColor = Color.Black;
				textBoxPassword.Text = password;
				textBoxPassword.ForeColor = Color.Black;
				textBoxPassword.UseSystemPasswordChar = true;
			}
		}
	}
}
