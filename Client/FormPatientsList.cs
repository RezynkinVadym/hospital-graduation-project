using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SharedLibrary;
using SharedLibrary.Validation;

namespace Admin
{
	public partial class FormPatientsList : Form
	{
		BindingSource bindingSource;
		FormAccount callingForm;
		FormLoading formLoading = new FormLoading();
		bool close = false;
		bool edit = false;
		int rowIdToEdit = 0;
		Patient patientToEdit;
		StringValidation validation;
		public FormPatientsList(FormAccount form)
		{
			InitializeComponent();
			Height = 530;
			callingForm = form;
			formLoading.StartPosition = FormStartPosition.CenterParent;
			comboBoxFields.SelectedIndex = 0;
			validation = new StringValidation();
			HubConnect.On <List<Patient>>("GetAllPatients", (patientList) =>
			{
				Invoker(delegate
				{
					bindingSource = new BindingSource { DataSource = patientList };
					dataGridViewPatients.DataSource = bindingSource;
				});
			});
			HubConnect.On<string>("AddPatientInvalid", (message) =>
			{
				ShowInvalidDataMessageBox(message);
			});
			HubConnect.On<Patient>("AddPatientValid", (patient) =>
			{
				Invoker(delegate {
					formLoading.Close();
					bindingSource.Add(patient);
				});
			});
			HubConnect.On<long>("DeletePatient", (id) =>
			{
				Invoker(delegate {
					Patient patient = bindingSource.Cast<Patient>().FirstOrDefault(p => p.ID == id);
					if (patient != null)
						bindingSource.Remove(patient);
					formLoading.Close();
				});
			});
			HubConnect.On<string>("EditPatientInvalid", (message) =>
			{
				Invoker(formLoading.Close);
				ShowInvalidDataMessageBox(message);
			});
			HubConnect.On<Patient>("EditPatientValid", (patient) =>
			{
				Invoker(delegate
				{
					int index = bindingSource.Cast<Patient>().ToList().FindIndex(p => p.ID == patient.ID);
					if(index != -1)
						bindingSource[index] = patient;
					formLoading.Close();
				});
			});
		}
		private void panelAccount_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void FormPatientsList_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Закрити цю форму?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.No)
			{
				close = false;
				e.Cancel = true;
			}
			else
			{
				HubConnect.Off("AddPatientInvalid");
				HubConnect.Off("AddPatientValid");
				HubConnect.Off("EditPatientInvalid");
				HubConnect.Off("EditPatientValid");
				HubConnect.Off("DeletePatient");
				HubConnect.Off("GetAllPatients");
				close = true;
				callingForm.Visible = true;
			}
		}

		private void buttonEdit_Click(object sender, EventArgs e)
		{
			if (!edit)//переносимо всі дані з виділеного рядка таблиці у елементи управління для редагування
			{
				if (dataGridViewPatients.SelectedRows.Count > 0 && dataGridViewPatients.SelectedRows[0].Cells[0].Value != null)
				{
					rowIdToEdit = Int32.Parse(dataGridViewPatients.SelectedRows[0].Cells[0].Value.ToString());
					string name = textBoxFirstName.Text = dataGridViewPatients.SelectedRows[0].Cells[1].Value.ToString();
					string surname = textBoxLastName.Text = dataGridViewPatients.SelectedRows[0].Cells[2].Value.ToString();
					string phone = textBoxPhone.Text = dataGridViewPatients.SelectedRows[0].Cells[4].Value.ToString();
					string diagnosis = textBoxDiagnosis.Text = dataGridViewPatients.SelectedRows[0].Cells[5].Value.ToString();
					DateTime birthDay = dateTimePicker.Value = DateTime.Parse(dataGridViewPatients.SelectedRows[0].Cells[3].Value.ToString());
					edit = true;
					buttonEdit.Text = "Підтвердити";
					patientToEdit = new Patient(rowIdToEdit, name, surname, birthDay, phone, diagnosis);
				}
				else
					MessageBox.Show("Для редагування необхідно спочатку виділити рядок", "Редагування", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else//відправка запиту на редагування обраного пацієнта по введеним данним
			{
				string name = textBoxFirstName.Text;
				string surname = textBoxLastName.Text;
				string phone = textBoxPhone.Text;
				string diagnosis = textBoxDiagnosis.Text;
				DateTime birthDay = dateTimePicker.Value;
				if (!(patientToEdit.FirstName == name && patientToEdit.LastName == surname && patientToEdit.Phone ==
					phone && patientToEdit.Diagnosis == diagnosis && patientToEdit.BirthDay == birthDay))
				{
					if (CheckDataShowMessageBox(name, surname, phone, diagnosis))
					{
						patientToEdit = new Patient(rowIdToEdit, name, surname, birthDay, phone, diagnosis);
						Task.Run(async () => await EditPatient(HubConnect.GetConnection(), rowIdToEdit, name, surname, birthDay, phone, diagnosis));
						edit = false;
						buttonEdit.Text = "Редагувати";
						formLoading.ShowDialog();
					}
				}
				else//дані не змінились, редагування не потрібно
				{
					buttonEdit.Text = "Редагувати";
					edit = false;
				}
					
			}
			buttonCancelEditing.Enabled = edit;
		}
		private static async Task EditPatient(HubConnection connection, long id, string firstName, string lastName, DateTime birthDay, string phone, string diagnosis)
		{
			try
			{
				await connection.InvokeAsync("EditPatient", id, firstName, lastName, birthDay, phone, diagnosis);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		private void dataGridViewPatients_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			edit = false;
			buttonEdit.Text = "Редагувати";
			buttonCancelEditing.Enabled = false;
		}
		private void buttonAdd_Click(object sender, EventArgs e)
		{
			string name = textBoxFirstName.Text;
			string surname = textBoxLastName.Text;
			string phone = textBoxPhone.Text;
			string diagnosis = textBoxDiagnosis.Text;
			DateTime birthDay = dateTimePicker.Value;
			if (CheckDataShowMessageBox(name, surname, phone, diagnosis))
			{
				Task.Run(async () => await AddPatient(HubConnect.GetConnection(), name, surname, birthDay, phone, diagnosis));
				formLoading.ShowDialog();
			}
		}
		private static async Task AddPatient(HubConnection connection, string firstName, string lastName, DateTime birthDay, string phone, string diagnosis)
		{
			try
			{
				await connection.InvokeAsync("AddPatient", firstName, lastName, birthDay, phone, diagnosis);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		private static async Task GetAllPatients(HubConnection connection)
		{
			try
			{
				await connection.InvokeAsync("GetAllPatients");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(!(Char.IsDigit(e.KeyChar) || e.KeyChar == (Char)Keys.Back))
				e.Handled = true;
			if (textBoxPhone.Text.Length == 10 && e.KeyChar != (Char)Keys.Back)
				e.Handled = true;
		}

		bool CheckDataShowMessageBox(string name, string surname, string phone, string diagnosis)
		{
			if (!validation.FirstName(name) || !validation.LastName(surname) || !validation.Phone(phone) || !validation.Diagnosis(diagnosis))
			{
				MessageBox.Show(validation.ErrorText, "Неправильні дані", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private void panelLogOut_Click(object sender, EventArgs e)
		{
			Close();
			if (close)
				callingForm.Close();
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (dataGridViewPatients.SelectedRows.Count > 0 && dataGridViewPatients.SelectedRows[0].Cells[0].Value != null)
			{
				long idToDelete = long.Parse(dataGridViewPatients.SelectedRows[0].Cells[0].Value.ToString());
				Task.Run(async () => await DeletePatient(HubConnect.GetConnection(), idToDelete));
				formLoading.ShowDialog();
			}
			else
				MessageBox.Show("Для видалення необхідно виділити рядок", "Видалення", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		private static async Task DeletePatient(HubConnection connection, long id)
		{
			try
			{
				await connection.InvokeAsync("DeletePatient", id);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		private void buttonFilter_Click(object sender, EventArgs e)
		{
			string filterCondition = textBoxFilterValue.Text;
			int fieldIndex = comboBoxFields.SelectedIndex;
			if (!string.IsNullOrWhiteSpace(filterCondition))
			{

				foreach (DataGridViewRow r in dataGridViewPatients.Rows)
				{
					if (r.Index != dataGridViewPatients.Rows.Count - 1)//Останній ряд пустий
					{
						if ((r.Cells[fieldIndex].Value).ToString().ToUpper().Contains(filterCondition.ToUpper()))
						{
							dataGridViewPatients.Rows[r.Index].Visible = true;
						}
						else
						{
							dataGridViewPatients.CurrentCell = null;
							dataGridViewPatients.Rows[r.Index].Visible = false;
						}
					}
				}
			}
			else
				foreach (DataGridViewRow r in dataGridViewPatients.Rows)
				{
					dataGridViewPatients.Rows[r.Index].Visible = true;
				}
		}

		private void buttonCancelEditing_Click(object sender, EventArgs e)
		{
			edit = false;
			buttonEdit.Text = "Редагувати";
			buttonCancelEditing.Enabled = false;
			textBoxDiagnosis.Text = string.Empty;
			textBoxPhone.Text = string.Empty;
			textBoxFirstName.Text = string.Empty;
			textBoxLastName.Text = string.Empty;
		}
		private void ShowInvalidDataMessageBox(string text)
		{
			MessageBox.Show(text, "Помилково введені дані", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

		private void FormPatientsList_Load(object sender, EventArgs e)
		{
			Task.Run(async () => await GetAllPatients(HubConnect.GetConnection()));//отримуємо всіх пацієнтів з бд для відображення на формі при відкритті
		}
	}
}
