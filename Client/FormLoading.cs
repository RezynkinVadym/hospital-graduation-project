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
	public partial class FormLoading : Form
	{
		public FormLoading()
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			Bitmap gif = new Bitmap("loading.gif");
			pictureBoxLoading.BackgroundImageLayout = ImageLayout.Stretch;
			pictureBoxLoading.Height = gif.Height;
			pictureBoxLoading.Width = gif.Width;
			pictureBoxLoading.Image = gif;
		}
	}
}
