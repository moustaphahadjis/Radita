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
    public partial class UpdateUser : Form
    {
        string id;
        public UpdateUser(string ID,string name, string prenom, string username, string mot)
        {
            InitializeComponent();
            textBox1.Text = name;
            textBox2.Text = prenom;
            textBox3.Text = username;
            textBox6.Text = mot;
            id = ID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.Users temp = new Classes.Users();

            if (!string.IsNullOrEmpty(textBox1.Text)
                && !string.IsNullOrEmpty(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text)
                && !string.IsNullOrEmpty(textBox4.Text)
                && !string.IsNullOrEmpty(textBox5.Text)
                && !string.IsNullOrEmpty(textBox6.Text))
            {
                if (textBox4.Text == textBox5.Text)
                {

                    try
                    {
                        temp.Modify(id,textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox6.Text);
                        MessageBox.Show("Informations mises à jour!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                    MessageBox.Show("Les deux mots de passe de correspondent pas");
            }
            else
                MessageBox.Show("Veuillez remplir toutes les cases");
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            Classes.design design = new Classes.design();
            button1 = design.button(button1);
            button2 = design.button(button2);
        }
    }
}
