using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radita
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            Classes.design design = new Classes.design();
            button1 = design.button(button1);
            button2 = design.button(button2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.Users temp = new Classes.Users();
            bool exist = false;

            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "")
            {
                exist = temp.CheckUser(textBox1.Text);
                if (exist == false)
                {
                    temp.Add(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), textBox3.Text, textBox4.Text, textBox5.Text);
                    MessageBox.Show("User has been created successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User already exists!");
                }
            }
            else
            {
                MessageBox.Show("Please fill in empty field(s)!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
