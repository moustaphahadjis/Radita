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
        public newClient(string tmp1, string tmp2)
        {
            InitializeComponent();
            name = tmp1;
            phone = tmp2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(metroTextBox1.Text) && !string.IsNullOrEmpty(metroTextBox2.Text))
            {
                Classes.Clients clients = new Classes.Clients();
                if (!clients.CheckClient(metroTextBox1.Text))
                {
                    clients.Add(metroTextBox1.Text, metroTextBox2.Text);
                }
            }
        }

        private void newClient_Load(object sender, EventArgs e)
        {
            metroTextBox1.Text = name;
            metroTextBox2.Text = phone;
        }
    }
}
