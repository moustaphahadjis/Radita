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
        public string username, nom, prenom;
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
                nom = temp.getName(textBox1.Text, textBox2.Text);
                prenom = temp.getPrenom(textBox1.Text, textBox2.Text);
                //MessageBox.Show("Welcome!");
                username = textBox1.Text;
                mainForm form = new mainForm(this);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Classes.design d = new Classes.design();
            button1 = d.button(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
