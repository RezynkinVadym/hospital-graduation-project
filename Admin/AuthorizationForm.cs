using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
	public partial class FormAuthorization : Form
	{
		string loginHint = "Введіть ваш логін";
		string passwordHint = "Введіть ваш пароль";
		FormLoading formLoad;
		public FormAuthorization(){
			InitializeComponent();
			NeedAHint(textBoxLogin, loginHint);
			NeedAHint(textBoxPassword, passwordHint);
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
			if (!AuthorizationCheck.CheckLogin(loginText)) { 
				
				successSignIn = false;
				labelLoginError.Text = AuthorizationCheck.ErrorText;
			}
			if (!AuthorizationCheck.CheckPassword(passwordText))
			{
				successSignIn = false;
				labelPasswordError.Text = AuthorizationCheck.ErrorText;
			}
			if (successSignIn)
			{
				SignInData.SignIn(loginText, passwordText, this);
				formLoad = new FormLoading();
				formLoad.StartPosition = FormStartPosition.CenterParent;
				formLoad.ShowDialog();
			}
		}

		private void buttonSignUp_Click(object sender, EventArgs e)
		{
			FormRegistration form = new FormRegistration(this);
			form.ShowDialog();
		}

		public void RegistrationComplete(string login, string password)
		{
			Invoke((MethodInvoker)delegate
			{
				textBoxLogin.Text = login;
				textBoxLogin.ForeColor = Color.Black;
				textBoxPassword.Text = password;
				textBoxPassword.ForeColor = Color.Black;
				textBoxPassword.UseSystemPasswordChar = true;
			});
		}
		public void SignInComplete(string result)
		{
			Invoke((MethodInvoker)delegate
			{
				formLoad.Close();
				labelLoginError.Text = string.Empty;
				labelPasswordError.Text = string.Empty;
			});
			if(result == "Немає користувача з цим логіном")
			{
				Invoke((MethodInvoker)delegate
				{
					labelLoginError.Text = result;
				});
			}
			else if (result == "Неправильний пароль")
			{
				Invoke((MethodInvoker)delegate
				{
					labelPasswordError.Text = result;
				});
			}
			else
			{
				Invoke((MethodInvoker)delegate
				{
					this.Visible = false;
				});
				new FormAccount(this, result).ShowDialog();
			}
		}
	}
}
