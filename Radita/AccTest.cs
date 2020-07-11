using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MySql.Data.MySqlClient;

namespace Radita
{
    public partial class AccTest : Form
    {
        public AccTest()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text.Trim() != "" && metroTextBox2.Text.Trim() != "" && metroTextBox3.Text.Trim() != "" && metroTextBox4.Text.Trim() != "" && metroTextBox5.Text.Trim() != "")
            {
                UserAccounts temp = new UserAccounts();
                temp.Add(metroTextBox1.Text, metroTextBox2.Text, metroComboBox1.SelectedItem.ToString(), metroTextBox3.Text, metroTextBox4.Text, metroTextBox5.Text);
            }
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'raditaDataSet.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.raditaDataSet.users);

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string searchVal = metroTextBox6.Text;
            metroGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            metroGrid1.ClearSelection();

            try
            {
                foreach(DataGridViewRow row in metroGrid1.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchVal))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            UserAccounts temp = new UserAccounts();

            try
            {
              foreach(DataGridViewRow row in metroGrid1.Rows)
                {
                    temp.Modify(metroTextBox1.Text, metroTextBox2.Text, metroComboBox1.SelectedItem.ToString(), metroTextBox3.Text, metroTextBox4.Text, metroTextBox5.Text);
                }
                MessageBox.Show("Records updated Successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            UserAccounts temp = new UserAccounts();
            metroGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                temp.Delete(metroTextBox6.Text);
                MessageBox.Show("Record deleted Successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
