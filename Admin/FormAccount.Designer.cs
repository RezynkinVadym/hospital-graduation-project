namespace Admin
{
	partial class FormAccount
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccount));
			this.pictureBoxAccountPhoto = new System.Windows.Forms.PictureBox();
			this.labelLogin = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panelLogOut = new System.Windows.Forms.Panel();
			this.labelSurname = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelDateOfBirth = new System.Windows.Forms.Label();
			this.labelSex = new System.Windows.Forms.Label();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.labelSexDescription = new System.Windows.Forms.Label();
			this.buttonPatientList = new System.Windows.Forms.Button();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.textBoxSurname = new System.Windows.Forms.TextBox();
			this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButtonFemale = new System.Windows.Forms.RadioButton();
			this.radioButtonMale = new System.Windows.Forms.RadioButton();
			this.buttonCancelEditing = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAccountPhoto)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxAccountPhoto
			// 
			this.pictureBoxAccountPhoto.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAccountPhoto.Image")));
			this.pictureBoxAccountPhoto.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxAccountPhoto.Name = "pictureBoxAccountPhoto";
			this.pictureBoxAccountPhoto.Size = new System.Drawing.Size(120, 120);
			this.pictureBoxAccountPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxAccountPhoto.TabIndex = 0;
			this.pictureBoxAccountPhoto.TabStop = false;
			// 
			// labelLogin
			// 
			this.labelLogin.AutoSize = true;
			this.labelLogin.Font = new System.Drawing.Font("Monotype Corsiva", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLogin.Location = new System.Drawing.Point(161, 26);
			this.labelLogin.Name = "labelLogin";
			this.labelLogin.Size = new System.Drawing.Size(153, 39);
			this.labelLogin.TabIndex = 1;
			this.labelLogin.Text = "SomeLogin";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(164, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(267, 25);
			this.label1.TabIndex = 2;
			this.label1.Text = "Локальний обліковий запис";
			// 
			// panelLogOut
			// 
			this.panelLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(21)))), ((int)(((byte)(47)))));
			this.panelLogOut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLogOut.BackgroundImage")));
			this.panelLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panelLogOut.Location = new System.Drawing.Point(551, 6);
			this.panelLogOut.Name = "panelLogOut";
			this.panelLogOut.Size = new System.Drawing.Size(35, 35);
			this.panelLogOut.TabIndex = 4;
			this.panelLogOut.Click += new System.EventHandler(this.panelLogOut_Click);
			// 
			// labelSurname
			// 
			this.labelSurname.AutoSize = true;
			this.labelSurname.Font = new System.Drawing.Font("Mongolian Baiti", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSurname.Location = new System.Drawing.Point(163, 155);
			this.labelSurname.Name = "labelSurname";
			this.labelSurname.Size = new System.Drawing.Size(112, 30);
			this.labelSurname.TabIndex = 5;
			this.labelSurname.Text = "Surname";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Font = new System.Drawing.Font("Mongolian Baiti", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelName.Location = new System.Drawing.Point(258, 155);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(79, 30);
			this.labelName.TabIndex = 6;
			this.labelName.Text = "Name";
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelEmail.Location = new System.Drawing.Point(164, 118);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(62, 24);
			this.labelEmail.TabIndex = 7;
			this.labelEmail.Text = "Email";
			// 
			// labelDateOfBirth
			// 
			this.labelDateOfBirth.AutoSize = true;
			this.labelDateOfBirth.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDateOfBirth.Location = new System.Drawing.Point(354, 205);
			this.labelDateOfBirth.Name = "labelDateOfBirth";
			this.labelDateOfBirth.Size = new System.Drawing.Size(120, 24);
			this.labelDateOfBirth.TabIndex = 8;
			this.labelDateOfBirth.Text = "DateOfBirth";
			// 
			// labelSex
			// 
			this.labelSex.AutoSize = true;
			this.labelSex.Font = new System.Drawing.Font("Mongolian Baiti", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSex.Location = new System.Drawing.Point(236, 248);
			this.labelSex.Name = "labelSex";
			this.labelSex.Size = new System.Drawing.Size(55, 30);
			this.labelSex.TabIndex = 9;
			this.labelSex.Text = "Sex";
			// 
			// buttonEdit
			// 
			this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(220)))), ((int)(((byte)(139)))));
			this.buttonEdit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonEdit.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonEdit.Location = new System.Drawing.Point(358, 17);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(178, 48);
			this.buttonEdit.TabIndex = 10;
			this.buttonEdit.Text = "Редагувати";
			this.buttonEdit.UseVisualStyleBackColor = false;
			this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(163, 202);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(220, 30);
			this.label2.TabIndex = 11;
			this.label2.Text = "День народження";
			// 
			// labelSexDescription
			// 
			this.labelSexDescription.AutoSize = true;
			this.labelSexDescription.Font = new System.Drawing.Font("Mongolian Baiti", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSexDescription.Location = new System.Drawing.Point(164, 248);
			this.labelSexDescription.Name = "labelSexDescription";
			this.labelSexDescription.Size = new System.Drawing.Size(87, 30);
			this.labelSexDescription.TabIndex = 12;
			this.labelSexDescription.Text = "Стать:";
			// 
			// buttonPatientList
			// 
			this.buttonPatientList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(155)))), ((int)(((byte)(171)))));
			this.buttonPatientList.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.buttonPatientList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPatientList.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonPatientList.Location = new System.Drawing.Point(191, 314);
			this.buttonPatientList.Name = "buttonPatientList";
			this.buttonPatientList.Size = new System.Drawing.Size(216, 48);
			this.buttonPatientList.TabIndex = 13;
			this.buttonPatientList.Text = "Список пацієнтів";
			this.buttonPatientList.UseVisualStyleBackColor = false;
			this.buttonPatientList.Click += new System.EventHandler(this.buttonPatientList_Click);
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxEmail.Location = new System.Drawing.Point(168, 111);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(168, 33);
			this.textBoxEmail.TabIndex = 14;
			this.textBoxEmail.Visible = false;
			// 
			// textBoxSurname
			// 
			this.textBoxSurname.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxSurname.Location = new System.Drawing.Point(168, 155);
			this.textBoxSurname.Name = "textBoxSurname";
			this.textBoxSurname.Size = new System.Drawing.Size(168, 33);
			this.textBoxSurname.TabIndex = 15;
			this.textBoxSurname.Visible = false;
			// 
			// dateTimePicker
			// 
			this.dateTimePicker.Location = new System.Drawing.Point(358, 202);
			this.dateTimePicker.MaxDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
			this.dateTimePicker.MinDate = new System.DateTime(1900, 1, 2, 0, 0, 0, 0);
			this.dateTimePicker.Name = "dateTimePicker";
			this.dateTimePicker.Size = new System.Drawing.Size(174, 26);
			this.dateTimePicker.TabIndex = 16;
			this.dateTimePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			this.dateTimePicker.Visible = false;
			// 
			// textBoxName
			// 
			this.textBoxName.Font = new System.Drawing.Font("Mongolian Baiti", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxName.Location = new System.Drawing.Point(343, 155);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(168, 33);
			this.textBoxName.TabIndex = 17;
			this.textBoxName.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButtonFemale);
			this.groupBox1.Controls.Add(this.radioButtonMale);
			this.groupBox1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(242, 236);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 60);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Стать";
			this.groupBox1.Visible = false;
			// 
			// radioButtonFemale
			// 
			this.radioButtonFemale.AutoSize = true;
			this.radioButtonFemale.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonFemale.Location = new System.Drawing.Point(125, 26);
			this.radioButtonFemale.Name = "radioButtonFemale";
			this.radioButtonFemale.Size = new System.Drawing.Size(87, 29);
			this.radioButtonFemale.TabIndex = 11;
			this.radioButtonFemale.Text = "Жінка";
			this.radioButtonFemale.UseVisualStyleBackColor = true;
			// 
			// radioButtonMale
			// 
			this.radioButtonMale.AutoSize = true;
			this.radioButtonMale.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonMale.Location = new System.Drawing.Point(18, 26);
			this.radioButtonMale.Name = "radioButtonMale";
			this.radioButtonMale.Size = new System.Drawing.Size(104, 29);
			this.radioButtonMale.TabIndex = 10;
			this.radioButtonMale.Text = "Чоловік";
			this.radioButtonMale.UseVisualStyleBackColor = true;
			// 
			// buttonCancelEditing
			// 
			this.buttonCancelEditing.BackColor = System.Drawing.Color.IndianRed;
			this.buttonCancelEditing.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
			this.buttonCancelEditing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancelEditing.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonCancelEditing.Location = new System.Drawing.Point(191, 314);
			this.buttonCancelEditing.Name = "buttonCancelEditing";
			this.buttonCancelEditing.Size = new System.Drawing.Size(216, 48);
			this.buttonCancelEditing.TabIndex = 19;
			this.buttonCancelEditing.Text = "Скасувати";
			this.buttonCancelEditing.UseVisualStyleBackColor = false;
			this.buttonCancelEditing.Visible = false;
			this.buttonCancelEditing.Click += new System.EventHandler(this.buttonCancelEditing_Click);
			// 
			// FormAccount
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 384);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.buttonPatientList);
			this.Controls.Add(this.dateTimePicker);
			this.Controls.Add(this.textBoxSurname);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.labelSexDescription);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonEdit);
			this.Controls.Add(this.labelSex);
			this.Controls.Add(this.labelDateOfBirth);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelSurname);
			this.Controls.Add(this.panelLogOut);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelLogin);
			this.Controls.Add(this.pictureBoxAccountPhoto);
			this.Controls.Add(this.buttonCancelEditing);
			this.Name = "FormAccount";
			this.Text = "Account";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAccount_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAccountPhoto)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxAccountPhoto;
		private System.Windows.Forms.Label labelLogin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelLogOut;
		private System.Windows.Forms.Label labelSurname;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelEmail;
		private System.Windows.Forms.Label labelDateOfBirth;
		private System.Windows.Forms.Label labelSex;
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelSexDescription;
		private System.Windows.Forms.Button buttonPatientList;
		private System.Windows.Forms.TextBox textBoxEmail;
		private System.Windows.Forms.TextBox textBoxSurname;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButtonFemale;
		private System.Windows.Forms.RadioButton radioButtonMale;
		private System.Windows.Forms.Button buttonCancelEditing;
	}
}