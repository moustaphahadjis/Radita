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
    public partial class newClient : Form
    {
        string name, phone;
        bool close;
        public newClient(string tmp1, string tmp2, bool tmp3)
        {
            InitializeComponent();
            name = tmp1;
            phone = tmp2;
            close = tmp3;
        }

        bool isNumber(string tmp)
        {
            bool result = true;
            for (int i = 0; i < tmp.Length; i++)
            {
                if (!char.IsDigit(tmp[i]))
                    result = false;
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(metroTextBox1.Text) && !string.IsNullOrEmpty(metroTextBox2.Text) && !string.IsNullOrEmpty(metroTextBox3.Text) && !string.IsNullOrEmpty(metroTextBox4.Text))
            {
                if(isNumber(metroTextBox2.Text) && isNumber(metroTextBox3.Text) && isNumber(metroTextBox4.Text))
                {
                    Classes.Clients clients = new Classes.Clients();
                    if (!clients.CheckClient(metroTextBox1.Text))
                    {
                        clients.Add(metroTextBox1.Text, metroTextBox2.Text, metroTextBox3.Text, metroTextBox4.Text);
                        Classes.historiquePartenaire tmp = new Classes.historiquePartenaire();
                        tmp.addNew(metroTextBox1.Text, metroTextBox2.Text, "Ajouté", metroTextBox3.Text + "-" + metroTextBox4.Text);

                        if (close)
                            this.Close();
                    }
                } 
            }
            else
            {
                MessageBox.Show("Valeur invalide");
            }

        }

        private void newClient_Load(object sender, EventArgs e)
        {
            metroTextBox1.Text = name;
            metroTextBox2.Text = phone;
            Classes.design design = new Classes.design();
            button1 = design.button(button1);
        }
    }
}
