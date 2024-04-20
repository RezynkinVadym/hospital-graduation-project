namespace Admin
{
	partial class FormConfirmRegistration
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxLogin = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.buttonBack = new System.Windows.Forms.Button();
			this.buttonConfirm = new System.Windows.Forms.Button();
			this.labelLoginError = new System.Windows.Forms.Label();
			this.labelPasswordError = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(46, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Створіть логін";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(46, 192);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(280, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "Придумайте надійний пароль";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(31, 34);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(323, 30);
			this.label3.TabIndex = 2;
			this.label3.Text = "Останній крок реєстрації";
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxLogin.Location = new System.Drawing.Point(51, 133);
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.Size = new System.Drawing.Size(289, 30);
			this.textBoxLogin.TabIndex = 3;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxPassword.Location = new System.Drawing.Point(51, 241);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(289, 30);
			this.textBoxPassword.TabIndex = 4;
			// 
			// buttonBack
			// 
			this.buttonBack.BackColor = System.Drawing.Color.IndianRed;
			this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonBack.Location = new System.Drawing.Point(12, 323);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(146, 46);
			this.buttonBack.TabIndex = 15;
			this.buttonBack.Text = "Назад";
			this.buttonBack.UseVisualStyleBackColor = false;
			this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
			// 
			// buttonConfirm
			// 
			this.buttonConfirm.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.buttonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonConfirm.ForeColor = System.Drawing.SystemColors.ControlText;
			this.buttonConfirm.Location = new System.Drawing.Point(235, 323);
			this.buttonConfirm.Name = "buttonConfirm";
			this.buttonConfirm.Size = new System.Drawing.Size(146, 46);
			this.buttonConfirm.TabIndex = 14;
			this.buttonConfirm.Text = "Підтвердити";
			this.buttonConfirm.UseVisualStyleBackColor = false;
			this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
			// 
			// labelLoginError
			// 
			this.labelLoginError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLoginError.ForeColor = System.Drawing.Color.Red;
			this.labelLoginError.Location = new System.Drawing.Point(12, 107);
			this.labelLoginError.Name = "labelLoginError";
			this.labelLoginError.Size = new System.Drawing.Size(369, 23);
			this.labelLoginError.TabIndex = 16;
			this.labelLoginError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPasswordError
			// 
			this.labelPasswordError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPasswordError.ForeColor = System.Drawing.Color.Red;
			this.labelPasswordError.Location = new System.Drawing.Point(12, 217);
			this.labelPasswordError.Name = "labelPasswordError";
			this.labelPasswordError.Size = new System.Drawing.Size(369, 23);
			this.labelPasswordError.TabIndex = 17;
			this.labelPasswordError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FormConfirmRegistration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(393, 403);
			this.Controls.Add(this.labelPasswordError);
			this.Controls.Add(this.labelLoginError);
			this.Controls.Add(this.buttonBack);
			this.Controls.Add(this.buttonConfirm);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxLogin);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormConfirmRegistration";
			this.Text = "FormConfirmRegistration";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxLogin;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.Button buttonConfirm;
		private System.Windows.Forms.Label labelLoginError;
		private System.Windows.Forms.Label labelPasswordError;
	}
}