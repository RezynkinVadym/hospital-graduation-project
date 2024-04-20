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
	public partial class FormAccount : Form
	{
		FormAuthorization formAuthorization;
		bool needToEdit = true;
		public FormAccount(FormAuthorization form, string accountData)
		{
			InitializeComponent();
			formAuthorization = form;
			pictureBoxAccountPhoto.Image = Image.FromFile("account_icon.png");
			pictureBoxAccountPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
			AccountData.InitializeData(accountData);
			labelLogin.Text = AccountData.GetLogin;
			labelSurname.Text = AccountData.GetSurname;
			Point labelNameLocation = new Point(labelSurname.Location.X + (labelSurname.Text.Length * 8 + 10), labelSurname.Location.Y);
			labelName.Location = labelNameLocation;
			labelName.Text = AccountData.GetName;
			labelEmail.Text = AccountData.GetMail;
			labelDateOfBirth.Text = AccountData.GetDateOfBirth.ToShortDateString();
			if (AccountData.GetSex == 'M')
				labelSex.Text = "Чоловік";
			else
				labelSex.Text = "Жінка";
			Image logOut = Image.FromFile("log_out_icon.png");
			panelLogOut.BackgroundImage = logOut;
		}
		private void panelLogOut_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Ви впевнені що хочете вийти з акаунту?", "Вихід з акаунту",
				MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				this.Close();
			}
		}

		private void FormAccount_FormClosed(object sender, FormClosedEventArgs e)
		{
			Invoke((MethodInvoker)delegate
			{
				formAuthorization.Visible = true;
			});
		}

		private void buttonEdit_Click(object sender, EventArgs e)
		{
			if (needToEdit)
			{
				InputChangeVisible();
				textBoxName.Text = labelName.Text;
				textBoxEmail.Text = labelEmail.Text;
				textBoxSurname.Text = labelSurname.Text;
				dateTimePicker.Value = DateTime.Parse(labelDateOfBirth.Text);
				radioButtonMale.Checked = labelSex.Text == "Чоловік";
				radioButtonFemale.Checked = labelSex.Text == "Жінка";
				needToEdit = false;
				buttonEdit.Text = "Підтвердити";
			}
			else
			{
				bool correctData = true;
				string messageBoxErrorCaption = "";
				string name = textBoxName.Text;
				string surname = textBoxSurname.Text;
				string mail = textBoxEmail.Text;
				DateTime dateOB = dateTimePicker.Value;
				char sex = radioButtonMale.Checked ? 'M' : 'W';
				if (!AuthorizationCheck.CheckName(name))
				{
					correctData = false;
					messageBoxErrorCaption = "Неправильне ім'я";
				} 
				else if (!AuthorizationCheck.CheckName(surname))
				{
					correctData = false;
					messageBoxErrorCaption = "Неправильне прізвище";
				}
				else if (!AuthorizationCheck.CheckEmail(mail))
				{
					correctData = false;
					messageBoxErrorCaption = "Неправильна пошта";
				}
				if (labelName.Text == name && labelSurname.Text == surname && labelEmail.Text == mail 
					&& dateTimePicker.Value == dateOB && labelSex.Text == (radioButtonMale.Checked ? "Чоловік" : "Жінка"))
				{
					InputChangeVisible();
					buttonEdit.Text = "Редагувати";
					needToEdit = true;
				}
				else if (!correctData)
					ShowMessageError(AuthorizationCheck.ErrorText, messageBoxErrorCaption);
				else
				{
					AccountData.EditData(name, surname, mail, dateOB, sex);
					InputChangeVisible();
					needToEdit = true;
					labelName.Text = name;
					labelSurname.Text = surname;
					labelEmail.Text = mail;
					dateTimePicker.Value = dateOB;
					labelSex.Text = radioButtonMale.Checked ? "Чоловік" : "Жінка";
					buttonEdit.Text = "Редагувати";
					Point labelNameLocation = new Point(labelSurname.Location.X + (labelSurname.Text.Length * 8 + 10), labelSurname.Location.Y);
					labelName.Location = labelNameLocation;
				}
			}
		}

		void ShowMessageError(string text, string caption)
		{
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		void InputChangeVisible()
		{
			labelSexDescription.Visible = !labelSexDescription.Visible;
			labelName.Visible = !labelName.Visible;
			labelEmail.Visible = !labelEmail.Visible;
			labelSurname.Visible = !labelSurname.Visible;
			textBoxEmail.Visible = !textBoxEmail.Visible;
			textBoxName.Visible = !textBoxName.Visible;
			textBoxSurname.Visible = !textBoxSurname.Visible;
			dateTimePicker.Visible = !dateTimePicker.Visible;
			groupBox1.Visible = !groupBox1.Visible;
			buttonCancelEditing.Visible = !buttonCancelEditing.Visible;
			buttonPatientList.Visible = !buttonPatientList.Visible;
		}

		private void buttonCancelEditing_Click(object sender, EventArgs e)
		{
			InputChangeVisible();
			buttonEdit.Text = "Редагувати";
			needToEdit = true;
		}

		private void buttonPatientList_Click(object sender, EventArgs e)
		{
			Visible = false;
			new FormPatientsList(this).ShowDialog();
		}
	}
}
