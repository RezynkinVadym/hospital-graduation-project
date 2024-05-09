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
using System.Xml.Linq;
using SharedLibrary.Validation;

namespace Admin
{
	public partial class FormAccount : Form
	{
		FormAuthorization formAuthorization;
		FormLoading formLoading;
		StringValidation validation;
		bool needToEdit = true;
		public FormAccount(FormAuthorization form, string firstName, string lastName, string email, char sex, DateTime birthDay, string login)
		{
			formAuthorization = form;
			formLoading = new FormLoading();
			formLoading.StartPosition = FormStartPosition.CenterParent;
			InitializeComponent();
			validation = new StringValidation();
			Visible = true;
			Image logOut = Image.FromFile("log_out_icon.png");
			panelLogOut.BackgroundImage = logOut;
			pictureBoxAccountPhoto.Image = Image.FromFile("account_icon.png");
			pictureBoxAccountPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

			SetDataToElements(firstName, lastName, email, birthDay);
			labelSex.Text = sex == 'M' ? "Чоловік" : "Жінка";
			labelLogin.Text = login;

			HubConnect.On<string>("EditAccountInvalid", (message) =>
			{
				Invoker(formLoading.Close);
				ShowMessageError(message, "Помилкові дані");
			});
			HubConnect.On<string, string, string, string, char, DateTime>("EditAccountValid", (message, name, surname, mail, gender, birth) =>
			{
				Invoker(formLoading.Close);
				if (message.Equals("Відредаговано"))
				{
					SetDataToElements(name, surname, mail, birth);
					Invoker(delegate () { labelSex.Text = gender == 'M' ? "Чоловік" : "Жінка"; });
					MessageBox.Show("Успішно відредаговано", "Редагування");
				}
				else if (message.Equals("Такого користувача не існує"))
				{
					ShowMessageError(message, "Неіснуючий логін акаунту");
				}
			});
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
			}
			else
			{
				bool correctData = true;
				string name = textBoxName.Text;
				string surname = textBoxSurname.Text;
				string email = textBoxEmail.Text;
				DateTime birthDay = dateTimePicker.Value;
				char sex = radioButtonMale.Checked ? 'M' : 'W';
				DateTime unEditBirthDay = DateTime.Parse(labelDateOfBirth.Text);
				if (!validation.FirstName(name) || !validation.LastName(surname) || !validation.Email(email))
					correctData = false;
				if (labelName.Text == name && labelSurname.Text == surname && labelEmail.Text == email //Якщо дані не змінились треба відмінити редагування
					&& unEditBirthDay == birthDay && labelSex.Text == (radioButtonMale.Checked ? "Чоловік" : "Жінка"))
				{
					InputChangeVisible();
				}
				else if (!correctData)
					ShowMessageError(validation.ErrorText, "Неправильні дані");
				else
				{
					Task.Run(async () => await EditAccount(HubConnect.GetConnection(), name, surname, email, sex, birthDay, labelLogin.Text));
					InputChangeVisible();
					formLoading.ShowDialog();
				}
			}
		}

		private static async Task EditAccount(HubConnection connection, string firstName, string lastName, string email, char sex, DateTime birthDay, string login)
		{
			try
			{
				await connection.InvokeAsync("EditAccount", firstName, lastName, email, sex, birthDay, login);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void SetDataToElements(string firstName, string lastName, string email, DateTime birthDay){
			labelName.Text = firstName;
			labelSurname.Text = lastName;
			labelEmail.Text = email;
			Invoker(delegate () { labelDateOfBirth.Text = birthDay.ToShortDateString(); });
			//надпис ім'я йде після прізвища, ім'я треба позиціонувати, інакше текст прізвища буде "напливати" на ім'я
			Point labelNameLocation = new Point(labelSurname.Location.X + (labelSurname.Text.Length * 8 + 10), labelSurname.Location.Y);
			labelName.Location = labelNameLocation;																						
		}

		void ShowMessageError(string text, string caption)
		{
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		void InputChangeVisible()//замінює надписи на поля для вводу нових значень та навпаки, а  також приховує/показує деякі кнопки
		{
			needToEdit = !needToEdit;
			buttonEdit.Text = needToEdit == true ? "Редагувати" : "Підтвердити";
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
		}

		private void buttonPatientList_Click(object sender, EventArgs e)
		{
			Visible = false;
			FormPatientsList form = new FormPatientsList(this);
			form.Show();
		}

		private void FormAccount_FormClosing(object sender, FormClosingEventArgs e)
		{
			HubConnect.Off("EditAccountInvalid");
			HubConnect.Off("EditAccountValid");
		}
		private void Invoker(Action action)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)delegate
				{
					action();
				});
			}
			else
				action();
		}
	}
}
