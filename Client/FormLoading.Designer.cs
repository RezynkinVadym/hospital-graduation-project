namespace Admin
{
	partial class FormLoading
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
			this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(127, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "Обробка...";
			// 
			// pictureBoxLoading
			// 
			this.pictureBoxLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBoxLoading.Location = new System.Drawing.Point(102, 68);
			this.pictureBoxLoading.Name = "pictureBoxLoading";
			this.pictureBoxLoading.Size = new System.Drawing.Size(173, 169);
			this.pictureBoxLoading.TabIndex = 1;
			this.pictureBoxLoading.TabStop = false;
			// 
			// FormLoading
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(384, 277);
			this.Controls.Add(this.pictureBoxLoading);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormLoading";
			this.Text = "Processing";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBoxLoading;
	}
}