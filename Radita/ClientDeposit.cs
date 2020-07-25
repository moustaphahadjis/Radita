using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Radita
{
    public partial class ClientDeposit : Form
    {
        public ClientDeposit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.Clients temp = new Classes.Clients();
            float val = 0;
            ulong phone = 0;

            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                try
                {
                    phone = Convert.ToUInt64(textBox2.Text);

                    val = temp.GetBalance(textBox1.Text, phone);
                    val += float.Parse(textBox3.Text);
                    temp.Deposit(textBox1.Text, phone, val);
                    MessageBox.Show("Money deposited successfully!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
