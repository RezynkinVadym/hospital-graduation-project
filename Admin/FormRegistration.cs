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
	public partial class FormRegistration : Form
	{
		FormAuthorization form;
		public FormRegistration(FormAuthorization formAuthorization)
		{
			InitializeComponent();
			form = formAuthorization;
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

			if (!AuthorizationCheck.CheckName(firstName))
			{
				labelFirstNameError.Text = AuthorizationCheck.ErrorText;
				successRegistration = false;
			}
			if(!AuthorizationCheck.CheckName(lastName))
			{
				labelLastNameError.Text = AuthorizationCheck.ErrorText;
				successRegistration = false;
			}
			if (!AuthorizationCheck.CheckEmail(email))
			{
				labelEmailError.Text = AuthorizationCheck.ErrorText;
				successRegistration = false;
			}
			if (successRegistration)
			{
				RegistrationData.RegistrationComplete(firstName, lastName, email, sex, dateOfBirth) ;
				this.Hide();
				new FormConfirmRegistration(this, form).ShowDialog();
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
