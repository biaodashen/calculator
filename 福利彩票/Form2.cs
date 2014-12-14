using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 福利彩票
{
    public partial class Form2 : Form
    {
        public int number { set; get; }
        public Form2()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                this.number = Convert.ToInt32(txtNumber.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) 
            {
                MessageBox.Show("请确保文本框输入了正确数字！");
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
