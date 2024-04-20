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

namespace Admin
{
	public partial class FormPatientsList : Form
	{
		PatientList patientList;
		FormAccount callingForm;
		FormLoading formLoading = new FormLoading();
		bool close = false;
		bool edit = false;
		int rowIdToEdit = 0;
		Patient patientToEdit;
		public FormPatientsList(FormAccount form)
		{
			InitializeComponent();
			Height = 530;
			patientList = new PatientList();
			callingForm = form;
			formLoading.StartPosition = FormStartPosition.CenterParent;
			dataGridViewPatients.DataSource = patientList.GetAllPatients();
			comboBoxFields.SelectedIndex = 0;
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
				close = true;
				callingForm.Visible = true;
			}
		}

		private void buttonEdit_Click(object sender, EventArgs e)
		{
			if (!edit)
			{
				if (dataGridViewPatients.SelectedRows.Count > 0)
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
			else
			{
				string name = textBoxFirstName.Text;
				string surname = textBoxLastName.Text;
				string phone = textBoxPhone.Text;
				string diagnosis = textBoxDiagnosis.Text;
				DateTime birthDay = dateTimePicker.Value;
				if (!(patientToEdit.FirstName == name && patientToEdit.LastName == surname && patientToEdit.Phone ==
					phone && patientToEdit.Diagnosis == diagnosis && patientToEdit.DateOfBirth == birthDay))
				{
					if (CheckDataShowMessageBox(name, surname, phone, diagnosis))
					{
						patientToEdit = new Patient(rowIdToEdit, name, surname, birthDay, phone, diagnosis);
						patientList.SendQuery("patient;edit;" + rowIdToEdit + ";" + name + ";" + surname + ";" + birthDay.ToString() + ";" + phone + ";" + diagnosis, this);
						edit = false;
						buttonEdit.Text = "Редагувати";
					}
				}
				else
				{
					buttonEdit.Text = "Редагувати";
					edit = false;
				}
					
			}
			buttonCancelEditing.Enabled = edit;
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
				patientList.SendQuery("patient;add;"  + name + ";" + surname + ";" + birthDay.ToString() + ";" + phone + ";" + diagnosis, this);
				formLoading.ShowDialog();
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
			bool correctData = true;
			string errorCaption = "";
			if (!AuthorizationCheck.CheckName(name))
			{
				correctData = false;
				errorCaption = "Ім'я";
			}
			else if (!AuthorizationCheck.CheckName(surname))
			{
				correctData = false;
				errorCaption = "Прізвище";
			}
			else if (!AuthorizationCheck.CheckPhone(phone))
			{
				correctData = false;
				errorCaption = "Номер телефону";
			}
			else if (!AuthorizationCheck.CheckDiagnosis(diagnosis))
			{
				correctData = false;
				errorCaption = "Діагноз";
			}
			if (correctData)
			{
				return true;
			}
			MessageBox.Show(AuthorizationCheck.ErrorText, errorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}
		internal void AddComplete(Patient patient, BindingSource bindingSource)
		{
			Invoke((MethodInvoker)delegate
			{
				formLoading.Close();
				bindingSource.Add(patient);
			});
		}
		internal void DeleteComplete(BindingSource bindingSource, int index)
		{
			Invoke((MethodInvoker)delegate
			{
				formLoading.Close();
				bindingSource.RemoveAt(index);
			});
		}
		internal void EditComplete(BindingSource bindingSource, int index)
		{
			Invoke((MethodInvoker)delegate
			{
				formLoading.Close();
				bindingSource[index] = patientToEdit;
			});
		}

		private void panelLogOut_Click(object sender, EventArgs e)
		{
			Close();
			if (close)
				callingForm.Close();
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (dataGridViewPatients.SelectedRows.Count > 0)
			{
				int idToDelete = Int32.Parse(dataGridViewPatients.SelectedRows[0].Cells[0].Value.ToString());
				patientList.SendQuery("patient;delete;" + idToDelete, this);
				formLoading.ShowDialog();
			}
			else
				MessageBox.Show("Для видалення необхідно виділити рядок", "Видалення", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void buttonFilter_Click(object sender, EventArgs e)
		{
			string filterCondition = textBoxFilterValue.Text;
			int fieldIndex = comboBoxFields.SelectedIndex;
			if (!string.IsNullOrWhiteSpace(filterCondition))
			{
				foreach (DataGridViewRow r in dataGridViewPatients.Rows)
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
	}
}
