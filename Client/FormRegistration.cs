using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary.Validation;

namespace Admin
{
	public partial class FormRegistration : Form
	{
		FormAuthorization form;
		FormLoading formLoading;
		StringValidation validation;
		public FormRegistration(FormAuthorization formAuthorization)
		{
			InitializeComponent();
			validation = new StringValidation();
			form = formAuthorization;
			formLoading = new FormLoading();
			formLoading.StartPosition = FormStartPosition.CenterParent;
			HubConnect.On<string>("RegistrationInvalidFirstName", (message) =>
			{
				Invoke((MethodInvoker)delegate
				{
					formLoading.Close();
					labelFirstNameError.Text = message;
				});
			});
			HubConnect.On<string>("RegistrationInvalidLastName", (message) =>
			{
				Invoke((MethodInvoker)delegate
				{
					formLoading.Close();
					labelLastNameError.Text = message;
				});
			});
			HubConnect.On<string>("RegistrationInvalidEmail", (message) =>
			{
				Invoke((MethodInvoker)delegate
				{
					formLoading.Close();
					labelEmailError.Text = message;
				});
			});
			HubConnect.On<object>("FirstRegistrationValid", (none) =>
			{
				if(InvokeRequired)
					Invoke((MethodInvoker)delegate {
						formLoading.Close();
						Visible = false;
						new FormConfirmRegistration(this, form).Show();
					});
				else
				{
					formLoading.Close();
					Visible = false;
					new FormConfirmRegistration(this, form).Show();
				}
			});
		}

		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			bool successRegistration = true;
			labelFirstNameError.Text = string.Empty;
			labelLastNameError.Text = string.Empty;
			labelEmailError.Text = string.Empty;
			string firstName = textBoxFirstName.Text;
			string lastName = textBoxLastName.Text;
			string email = textBoxEmail.Text;
			DateTime dateOfBirth = dateTimePicker.Value;
			char sex;
			if (radioButtonFemale.Checked)
				sex = 'W';
			else
				sex = 'M';

			if (!validation.FirstName(firstName))
			{
				labelFirstNameError.Text = validation.ErrorText;
				successRegistration = false;
			}
			if (!validation.LastName(lastName))
			{
				labelLastNameError.Text = validation.ErrorText;
				successRegistration = false;
			}
			if (!validation.Email(email))
			{
				labelEmailError.Text = validation.ErrorText;
				successRegistration = false;
			}
			if (successRegistration)
			{
				Task.Run(async () => await Registration(HubConnect.GetConnection(), firstName, lastName, email, sex, dateOfBirth));
				formLoading.ShowDialog();
			}
		}
		private static async Task Registration(HubConnection connection, string firstName, string lastName, string email, char sex, DateTime birthDay)
		{
			try
			{
				await connection.InvokeAsync("FirstStepRegistration", firstName, lastName, email, sex, birthDay);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			form.Visible = true;
			Close();
		}
		private void FormRegistration_FormClosing(object sender, FormClosingEventArgs e)
		{
			HubConnect.Off("RegistrationInvalidFirstName");
			HubConnect.Off("RegistrationInvalidLastName");
			HubConnect.Off("RegistrationInvalidEmail");
			HubConnect.Off("FirstRegistrationValid");
		}
	}
}
