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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool check = false;
            Classes.Users temp = new Classes.Users();
            check = temp.CheckPass(textBox1.Text, textBox2.Text);
            if (check == true)
            {
                MessageBox.Show("Welcome!");
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password!");
            }
        }
    }
}
