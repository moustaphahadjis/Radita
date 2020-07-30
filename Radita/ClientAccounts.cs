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
    public partial class ClientAccounts : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private string conn = "server=localhost;user id = root; database=radita";

        public ClientAccounts()
        {
            InitializeComponent();
        }

        /******Method to load database******/
        public void GetDataSet()
        {
            try
            {
                string load = "select * from clients";

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

        private void ClientAccounts_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            GetDataSet();
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
            newClient a1 = new newClient("","");
            a1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientDeposit a1 = new ClientDeposit();
            a1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Classes.Clients temp = new Classes.Clients();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete Client", MessageBoxButtons.YesNo);
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
    }
}
