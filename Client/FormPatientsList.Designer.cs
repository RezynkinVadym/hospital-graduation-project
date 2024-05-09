namespace Admin
{
	partial class FormPatientsList
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatientsList));
			this.dataGridViewPatients = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.panelAccount = new System.Windows.Forms.Panel();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.panelLogOut = new System.Windows.Forms.Panel();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.textBoxDiagnosis = new System.Windows.Forms.TextBox();
			this.labelSurname = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonFilter = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxFields = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.buttonCancelEditing = new System.Windows.Forms.Button();
			this.textBoxFilterValue = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatients)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewPatients
			// 
			this.dataGridViewPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewPatients.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridViewPatients.Location = new System.Drawing.Point(12, 60);
			this.dataGridViewPatients.MultiSelect = false;
			this.dataGridViewPatients.Name = "dataGridViewPatients";
			this.dataGridViewPatients.ReadOnly = true;
			this.dataGridViewPatients.RowHeadersWidth = 62;
			this.dataGridViewPatients.RowTemplate.Height = 28;
			this.dataGridViewPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewPatients.Size = new System.Drawing.Size(735, 375);
			this.dataGridViewPatients.TabIndex = 0;
			this.dataGridViewPatients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPatients_CellClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(276, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(221, 32);
			this.label1.TabIndex = 1;
			this.label1.Text = "Список пацієнтів";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelAccount
			// 
			this.panelAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelAccount.BackgroundImage")));
			this.panelAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panelAccount.Location = new System.Drawing.Point(887, 7);
			this.panelAccount.Name = "panelAccount";
			this.panelAccount.Size = new System.Drawing.Size(50, 50);
			this.panelAccount.TabIndex = 3;
			this.panelAccount.Click += new System.EventHandler(this.panelAccount_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(226)))), ((int)(((byte)(187)))));
			this.buttonAdd.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAdd.Location = new System.Drawing.Point(765, 78);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(172, 61);
			this.buttonAdd.TabIndex = 4;
			this.buttonAdd.Text = "Створити";
			this.buttonAdd.UseVisualStyleBackColor = false;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonEdit
			// 
			this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(187)))), ((int)(((byte)(227)))));
			this.buttonEdit.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonEdit.Location = new System.Drawing.Point(765, 159);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(172, 61);
			this.buttonEdit.TabIndex = 5;
			this.buttonEdit.Text = "Редагувати";
			this.buttonEdit.UseVisualStyleBackColor = false;
			this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
			// 
			// buttonDelete
			// 
			this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
			this.buttonDelete.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonDelete.Location = new System.Drawing.Point(765, 242);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(172, 61);
			this.buttonDelete.TabIndex = 6;
			this.buttonDelete.Text = "Видалити";
			this.buttonDelete.UseVisualStyleBackColor = false;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// panelLogOut
			// 
			this.panelLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(21)))), ((int)(((byte)(47)))));
			this.panelLogOut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLogOut.BackgroundImage")));
			this.panelLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panelLogOut.Location = new System.Drawing.Point(902, 702);
			this.panelLogOut.Name = "panelLogOut";
			this.panelLogOut.Size = new System.Drawing.Size(35, 35);
			this.panelLogOut.TabIndex = 7;
			this.panelLogOut.Click += new System.EventHandler(this.panelLogOut_Click);
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxLastName.Location = new System.Drawing.Point(397, 488);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.Size = new System.Drawing.Size(242, 30);
			this.textBoxLastName.TabIndex = 8;
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxFirstName.Location = new System.Drawing.Point(60, 488);
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.Size = new System.Drawing.Size(242, 30);
			this.textBoxFirstName.TabIndex = 9;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxPhone.Location = new System.Drawing.Point(123, 569);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(146, 30);
			this.textBoxPhone.TabIndex = 12;
			this.textBoxPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPhone_KeyPress);
			// 
			// textBoxDiagnosis
			// 
			this.textBoxDiagnosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDiagnosis.Location = new System.Drawing.Point(397, 569);
			this.textBoxDiagnosis.Name = "textBoxDiagnosis";
			this.textBoxDiagnosis.Size = new System.Drawing.Size(527, 30);
			this.textBoxDiagnosis.TabIndex = 13;
			// 
			// labelSurname
			// 
			this.labelSurname.AutoSize = true;
			this.labelSurname.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSurname.Location = new System.Drawing.Point(464, 460);
			this.labelSurname.Name = "labelSurname";
			this.labelSurname.Size = new System.Drawing.Size(96, 25);
			this.labelSurname.TabIndex = 14;
			this.labelSurname.Text = "Прізвище";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelName.Location = new System.Drawing.Point(160, 460);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(43, 25);
			this.labelName.TabIndex = 15;
			this.labelName.Text = "Ім\'я";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(747, 464);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(177, 25);
			this.label3.TabIndex = 16;
			this.label3.Text = "День народження";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(57, 541);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(164, 25);
			this.label5.TabIndex = 18;
			this.label5.Text = "Номер телефону";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(632, 541);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(81, 25);
			this.label6.TabIndex = 19;
			this.label6.Text = "Діагноз";
			// 
			// dateTimePicker
			// 
			this.dateTimePicker.Location = new System.Drawing.Point(752, 492);
			this.dateTimePicker.MaxDate = new System.DateTime(2024, 2, 18, 0, 0, 0, 0);
			this.dateTimePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.dateTimePicker.Name = "dateTimePicker";
			this.dateTimePicker.Size = new System.Drawing.Size(172, 26);
			this.dateTimePicker.TabIndex = 20;
			this.dateTimePicker.Value = new System.DateTime(2024, 2, 18, 0, 0, 0, 0);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(57, 569);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 25);
			this.label2.TabIndex = 21;
			this.label2.Text = "+(38)";
			// 
			// buttonFilter
			// 
			this.buttonFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(216)))));
			this.buttonFilter.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonFilter.Location = new System.Drawing.Point(10, 628);
			this.buttonFilter.Name = "buttonFilter";
			this.buttonFilter.Size = new System.Drawing.Size(238, 49);
			this.buttonFilter.TabIndex = 22;
			this.buttonFilter.Text = "Застосувати фільтр";
			this.buttonFilter.UseVisualStyleBackColor = false;
			this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(248, 639);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(84, 27);
			this.label4.TabIndex = 23;
			this.label4.Text = "на поле";
			// 
			// comboBoxFields
			// 
			this.comboBoxFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFields.FormattingEnabled = true;
			this.comboBoxFields.Items.AddRange(new object[] {
            "Id",
            "FirstName",
            "LastName",
            "DateOfBirth",
            "Phone",
            "Diagnosis"});
			this.comboBoxFields.Location = new System.Drawing.Point(338, 641);
			this.comboBoxFields.Name = "comboBoxFields";
			this.comboBoxFields.Size = new System.Drawing.Size(144, 28);
			this.comboBoxFields.TabIndex = 24;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.Location = new System.Drawing.Point(486, 639);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(209, 27);
			this.label7.TabIndex = 25;
			this.label7.Text = "що містить значення";
			// 
			// buttonCancelEditing
			// 
			this.buttonCancelEditing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
			this.buttonCancelEditing.Enabled = false;
			this.buttonCancelEditing.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCancelEditing.Location = new System.Drawing.Point(765, 329);
			this.buttonCancelEditing.Name = "buttonCancelEditing";
			this.buttonCancelEditing.Size = new System.Drawing.Size(172, 71);
			this.buttonCancelEditing.TabIndex = 26;
			this.buttonCancelEditing.Text = "Скасувати редагування";
			this.buttonCancelEditing.UseVisualStyleBackColor = false;
			this.buttonCancelEditing.Click += new System.EventHandler(this.buttonCancelEditing_Click);
			// 
			// textBoxFilterValue
			// 
			this.textBoxFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxFilterValue.Location = new System.Drawing.Point(703, 639);
			this.textBoxFilterValue.Name = "textBoxFilterValue";
			this.textBoxFilterValue.Size = new System.Drawing.Size(221, 30);
			this.textBoxFilterValue.TabIndex = 27;
			// 
			// FormPatientsList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(949, 803);
			this.Controls.Add(this.textBoxFilterValue);
			this.Controls.Add(this.buttonCancelEditing);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.comboBoxFields);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.buttonFilter);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateTimePicker);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelSurname);
			this.Controls.Add(this.textBoxDiagnosis);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.textBoxFirstName);
			this.Controls.Add(this.textBoxLastName);
			this.Controls.Add(this.panelLogOut);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.buttonEdit);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.panelAccount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridViewPatients);
			this.Name = "FormPatientsList";
			this.Text = "FormPatientsList";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPatientsList_FormClosing);
			this.Load += new System.EventHandler(this.FormPatientsList_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatients)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewPatients;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelAccount;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Panel panelLogOut;
		private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.TextBox textBoxFirstName;
		private System.Windows.Forms.TextBox textBoxPhone;
		private System.Windows.Forms.TextBox textBoxDiagnosis;
		private System.Windows.Forms.Label labelSurname;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonFilter;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxFields;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button buttonCancelEditing;
		private System.Windows.Forms.TextBox textBoxFilterValue;
	}
}