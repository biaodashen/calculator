using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace 福利彩票
{
    public partial class Form1 : Form
    {
        Form2 form2;
        StringBuilder code;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK) 
            {
                txtBox2.Text = form2.number.ToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
               
            int[] ran = new int[33];
            int[] red = new int[6];
            int index;
            int blue;
            for (int i = 1; i <= 33; i++) 
            {

                ran[i-1] = i ;
            }

            //MessageBox.Show(ran[30].ToString());

            Random random = new Random();

            index = random.Next(33);

            red[0] = ran[index];
            ran[index] = 0;

            for (int j = 1; j < 6; j++) 
            {
                
             //   MessageBox.Show(index.ToString());
                index = random.Next(33);

                if (ran[index] != 0)
                {
                    red[j] = ran[index];
                    ran[index] = 0;
                }
                else 
                {
                    j--;
                }
            }
            

            Array.Sort(red);
          
           

            blue = random.Next(1, 17);

            txtBox1.Text = red[0].ToString() + ",";

            for (int i = 1; i < 6; i++) 
            {
                txtBox1.Text += red[i].ToString() + ","; 
            }

            txtBox1.Text += blue.ToString();


              
        }

      

        private void button3_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            try
            {
                for (int i = 0; i < Convert.ToInt32(txtBox2.Text); i++)
                {
                    Thread.Sleep(25);
                    this.GetNumber();



                }
            }
            catch (Exception) 
            {
                MessageBox.Show("投入数量的值不合理！");
            }

              
        }

        private void GetNumber() 
        {
            int[] ran = new int[33];
            int[] red = new int[6];
            int[] count = new int[7];
            int index;
            int blue;
            code = new StringBuilder();
            
            for (int i = 1; i <= 33; i++)
            {

                ran[i - 1] = i;
            }

            //MessageBox.Show(ran[30].ToString());

            Random random = new Random();

            index = random.Next(33);

            red[0] = ran[index];
            ran[index] = 0;

            for (int j = 1; j < 6; j++)
            {

                index = random.Next(33);

                if (ran[index] != 0)
                {
                    red[j] = ran[index];
                    ran[index] = 0;
                }
                else
                {
                    j--;
                }
            }


            Array.Sort(red);

            for (int i = 0; i < 6; i++)
            {
                count[i] = red[i];
            }

            blue = random.Next(1, 17);
            count[6] = blue;

            

            for (int i = 0; i < count.Length-1; i++)
            {
                code.Append(count[i]);
                code.Append(",");
            }

            code.Append(count[6].ToString());
            

            
            listBox1.Items.Add(code.ToString());
                
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            int sum = 0;
            string[] prize  ;
            string[] auto   ;

            try
            {

                int index = listBox1.SelectedIndex;

                prize = txtBox1.Text.Split(',');
               

                if (index >= 0 && index < listBox1.Items.Count)
                {
                    auto =  listBox1.SelectedItem.ToString().Split(',');

                    if (Convert.ToInt32(prize[6]) == Convert.ToInt32(auto[6])) sum += 10;

                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (Convert.ToInt32(prize[j]) == Convert.ToInt32(auto[i]))
                            {
                                sum += 1;
                                break;
                            }

                        }

                    }

                    txtBox3.Text = sum.ToString();
                }


            }

            catch (Exception) 
            {

            }

        }

    }
}
