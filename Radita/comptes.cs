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
    public partial class comptes : Form
    {
        DataTable dt = new DataTable();
        public comptes()
        {
            InitializeComponent();
        }
        void refresh()
        {
            Classes.Clients tmp = new Classes.Clients();
            dt = tmp.getAll();


            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].HeaderText = "Noms";
            dataGridView1.Columns[4].HeaderText = "solde";
            Classes.design design = new Classes.design();
            dataGridView1 = design.datagridview(dataGridView1);
            button1 = design.button(button1);
            button2 = design.button(button2);
        }
        private void comptes_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows[0] != null)
                {
                    textBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rembourser tmp = new rembourser(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            tmp.Closed += (s, args) => this.refresh();
            tmp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientDeposit tmp = new ClientDeposit(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            tmp.Closed += (s, args) => this.refresh();
            tmp.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
