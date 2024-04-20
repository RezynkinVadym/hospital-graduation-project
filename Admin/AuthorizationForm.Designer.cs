namespace Admin
{
	partial class FormAuthorization
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxLogin = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.buttonSignIn = new System.Windows.Forms.Button();
			this.buttonSignUp = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelLoginError = new System.Windows.Forms.Label();
			this.labelPasswordError = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Palatino Linotype", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.label1.Location = new System.Drawing.Point(90, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(278, 55);
			this.label1.TabIndex = 0;
			this.label1.Text = "Авторизація";
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.Location = new System.Drawing.Point(100, 106);
			this.textBoxLogin.MaxLength = 30;
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.Size = new System.Drawing.Size(253, 26);
			this.textBoxLogin.TabIndex = 1;
			this.textBoxLogin.TabStop = false;
			this.textBoxLogin.Click += new System.EventHandler(this.textBoxLogin_Click);
			this.textBoxLogin.Leave += new System.EventHandler(this.textBoxLogin_Leave);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(100, 163);
			this.textBoxPassword.MaxLength = 30;
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(253, 26);
			this.textBoxPassword.TabIndex = 2;
			this.textBoxPassword.TabStop = false;
			this.textBoxPassword.Click += new System.EventHandler(this.textBoxPassword_Click);
			this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
			// 
			// buttonSignIn
			// 
			this.buttonSignIn.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSignIn.Location = new System.Drawing.Point(69, 218);
			this.buttonSignIn.Name = "buttonSignIn";
			this.buttonSignIn.Size = new System.Drawing.Size(138, 53);
			this.buttonSignIn.TabIndex = 3;
			this.buttonSignIn.Text = "Вхід";
			this.buttonSignIn.UseVisualStyleBackColor = true;
			this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
			// 
			// buttonSignUp
			// 
			this.buttonSignUp.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSignUp.Location = new System.Drawing.Point(250, 218);
			this.buttonSignUp.Name = "buttonSignUp";
			this.buttonSignUp.Size = new System.Drawing.Size(138, 53);
			this.buttonSignUp.TabIndex = 4;
			this.buttonSignUp.Text = "Реєстрація";
			this.buttonSignUp.UseVisualStyleBackColor = true;
			this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Navy;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(459, 77);
			this.panel1.TabIndex = 7;
			// 
			// labelLoginError
			// 
			this.labelLoginError.BackColor = System.Drawing.Color.Transparent;
			this.labelLoginError.ForeColor = System.Drawing.Color.Red;
			this.labelLoginError.Location = new System.Drawing.Point(12, 80);
			this.labelLoginError.Name = "labelLoginError";
			this.labelLoginError.Size = new System.Drawing.Size(435, 23);
			this.labelLoginError.TabIndex = 5;
			this.labelLoginError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPasswordError
			// 
			this.labelPasswordError.BackColor = System.Drawing.Color.Transparent;
			this.labelPasswordError.ForeColor = System.Drawing.Color.Red;
			this.labelPasswordError.Location = new System.Drawing.Point(12, 140);
			this.labelPasswordError.Name = "labelPasswordError";
			this.labelPasswordError.Size = new System.Drawing.Size(435, 20);
			this.labelPasswordError.TabIndex = 6;
			this.labelPasswordError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FormAuthorization
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 336);
			this.Controls.Add(this.labelPasswordError);
			this.Controls.Add(this.labelLoginError);
			this.Controls.Add(this.buttonSignUp);
			this.Controls.Add(this.buttonSignIn);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxLogin);
			this.Controls.Add(this.panel1);
			this.Name = "FormAuthorization";
			this.Text = "Authorization";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxLogin;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Button buttonSignIn;
		private System.Windows.Forms.Button buttonSignUp;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelLoginError;
		private System.Windows.Forms.Label labelPasswordError;
	}
}

