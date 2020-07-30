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
    public partial class UserAccounts : Form
    {

        private BindingSource bindingSource1 = new BindingSource();
        private string conn = "server=localhost;user id = root; database=radita";

        public UserAccounts()
        {
            InitializeComponent();
        }

        /******Method to load database******/
        public void GetDataSet()
        {
            try
            {
                string load = "select * from users";

                MySqlDataAdapter adp = new MySqlDataAdapter(load, conn);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adp);

                DataTable table = new DataTable();
                adp.Fill(table);
                bindingSource1.DataSource = table;

                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchVal = textBox1.Text;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ClearSelection();

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchVal))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form a1 = new NewUser();
            a1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form a1 = new UpdateUser();
            a1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Classes.Users temp = new Classes.Users();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete User", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        temp.Delete(row.Cells[1].Value.ToString());
                        GetDataSet();
                    }
                    MessageBox.Show("Record(s) deleted Successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }

        private void UserAccounts_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            GetDataSet();
        }
    }
}
