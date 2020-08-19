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
        void refresh()
        {
            dataGridView1.DataSource = bindingSource1;
            GetDataSet();
            dataGridView1.Columns[1].HeaderText = "Noms";
            dataGridView1.Columns[4].HeaderText = "solde";
            Classes.design design = new Classes.design();
            dataGridView1 = design.datagridview(dataGridView1);

            button1 = design.button(button1);
            button2 = design.button(button2);
            button3 = design.button(button3);
            button4 = design.button(button4);
        }
        private void ClientAccounts_Load(object sender, EventArgs e)
        {
            refresh();
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
            newClient a1 = new newClient("","",true);
            a1.Closed += (s, args) => this.refresh();
            a1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ClientDeposit a1 = new ClientDeposit();
            //a1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Classes.Clients temp = new Classes.Clients();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
    }
}
