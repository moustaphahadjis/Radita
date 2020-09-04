using MySqlX.XDevAPI.Relational;
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
    public partial class contrat : Form
    {
        DataTable dt = new DataTable();
        public contrat()
        {
            InitializeComponent();
        }
        void refresh()
        {
            Classes.scheduler tmp = new Classes.scheduler();
            dt = tmp.getAll();

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].HeaderText = "Noms";
            dataGridView1.Columns[2].HeaderText = "telephone";
            Classes.design design = new Classes.design();
            dataGridView1 = design.datagridview(dataGridView1);

            button1 = design.button(button1);
            button2 = design.button(button2);
            button3 = design.button(button3);
            button4 = design.button(button4);
        }
        private void contrat_Load(object sender, EventArgs e)
        {
            refresh();
        }
        bool validRow()
        {
            bool r = false;
            if (dataGridView1.Rows.Count > 0)
                if (dataGridView1.SelectedRows.Count > 0)
                    if (dataGridView1.SelectedRows[0] != null)
                        r = true;
            return r;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(validRow())
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Voulez Vous vraiment annuler ce Contrat?", "Annuler", MessageBoxButtons.YesNo);
                if(result==DialogResult.Yes)
                {
                    Classes.scheduler tmp = new Classes.scheduler();
                    tmp.remove(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));

                    Classes.historiqueCouture tmp2 = new Classes.historiqueCouture();
                    tmp2.addNew(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), "Annulé");
                    refresh();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            modifierContrat tmp = new modifierContrat(
                dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), 
                dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[4].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[5].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            tmp.Closed += (s, args) => this.refresh();
            tmp.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addContrat tmp = new addContrat();
            tmp.Closed += (s, args) => this.refresh();
            tmp.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(validRow())
            {
                if(Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[5].Value.ToString())>=0)
                {
                    if(MessageBox.Show("Il reste "+dataGridView1.SelectedRows[0].Cells[5].Value.ToString()+" à payer \nContinuer?","Completer cetter transaction",MessageBoxButtons.YesNo)==DialogResult.Yes)
                    {
                        Classes.historiqueCouture tmp = new Classes.historiqueCouture();
                        tmp.addNew(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), "Payé");
                        Classes.scheduler tmp2 = new Classes.scheduler();
                        tmp2.remove(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                        this.refresh();
                    }
                }
            }
        }
    }
}
