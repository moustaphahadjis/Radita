using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Radita
{
    public partial class newWork : Form
    {
        int progressCounter;
        bool allReady;

        DataTable dtClients;
        public newWork()
        {
            InitializeComponent();
            progressCounter = 0;
            allReady = false;
        }

        private void newWork_Load(object sender, EventArgs e)
        {
            refresh();
        }

        void refresh()
        {

            Classes.Clients clients = new Classes.Clients();
            dtClients = clients.getAll();
            //adding clients and employees to autocomplete;
            metroTextBox1.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            metroTextBox2.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            

            if(dtClients.Rows.Count>0)
                foreach(DataRow row in dtClients.Rows)
                {
                    metroTextBox1.AutoCompleteCustomSource.Add(row.ItemArray[1].ToString());
                    metroTextBox2.AutoCompleteCustomSource.Add(row.ItemArray[2].ToString());
                }


            Classes.design design = new Classes.design();
            button1 = design.button(button1);
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void updateProgress()
        {
            int counter = 0;
            if (!string.IsNullOrEmpty(metroTextBox1.Text))
            {
                counter++;
            }
            if (!string.IsNullOrEmpty(metroTextBox2.Text))
            {
                counter++;
            }

            if (!string.IsNullOrEmpty(metroTextBox3.Text))
                if (isNumber(metroTextBox3.Text))
                    if (Convert.ToInt64(metroTextBox3.Text) >= 0)
                    {
                        counter++;
                    }
            if (!string.IsNullOrEmpty(metroTextBox4.Text))
                if (isNumber(metroTextBox3.Text))
                    if (Convert.ToInt64(metroTextBox4.Text) >= 0)
                    {
                        counter++;
                    }
            
            if (metroDateTime1.Value.CompareTo(DateTime.Now) >= 0)
            {
                counter++;
            }

            progressCounter = counter;

            int progressSplit = 100 / 5;

            switch (progressCounter)
            {
                case 1:
                    metroProgressSpinner1.Value = progressSplit;
                    allReady = false;
                    break;
                case 2:
                    metroProgressSpinner1.Value = progressSplit * 2;
                    allReady = false;
                    break;
                case 3:
                    metroProgressSpinner1.Value = progressSplit * 3;
                    allReady = false;
                    break;
                case 4:
                    metroProgressSpinner1.Value = progressSplit * 4;
                    allReady = false;
                    break;
                case 5:
                    metroProgressSpinner1.Value = progressSplit * 5;
                    allReady = true;
                    break;
                default:
                    metroProgressSpinner1.Value = 0;
                    allReady = false;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int counter = 0;
            if(!string.IsNullOrEmpty(metroTextBox1.Text))
            {
                counter++;
            }
            if (!string.IsNullOrEmpty(metroTextBox2.Text))
            {
                counter++;
            }

            if (!string.IsNullOrEmpty(metroTextBox3.Text))
                if (isNumber(metroTextBox3.Text))
                    if (Convert.ToInt64(metroTextBox3.Text) >= 0)
                    {
                        counter++;
                    }
            if (!string.IsNullOrEmpty(metroTextBox4.Text))
                if (isNumber(metroTextBox3.Text))
                    if (Convert.ToInt64(metroTextBox4.Text) >= 0)
                    {
                        counter++;
                    }
           
            if (metroDateTime1.Value.Date.DayOfYear>(DateTime.Now.Date.DayOfYear) && metroDateTime1.Value.Date.Year > (DateTime.Now.Date.Year))
            {
                counter++;
            }

            progressCounter = counter;
            updateProgress();
        }

        bool isNumber(string tmp)
        {
            bool result = true;
            for(int i=0; i<tmp.Length;i++)
            {
                if (!char.IsDigit(tmp[i]))
                    result = false;
            }
            return result;
        }
        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateProgress(object sender, EventArgs e)
        {
            updateProgress();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //check if client is in the database
            bool exist = false;
            foreach (DataRow row in dtClients.Rows)
            {
                if (metroTextBox1.Text == row.ItemArray[1].ToString() && metroTextBox2.Text == row.ItemArray[2].ToString())
                {
                    exist = true;
                }
            }

            if (!exist)
            {
                var result = MessageBox.Show("Ce client n'existe pas dans la base de données \nVoulez vous l'ajouter?", "Ajouter nouveau client", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    newClient newClient = new newClient(metroTextBox1.Text, metroTextBox2.Text, true);
                    newClient.Closed += (s, args) => this.refresh();
                    newClient.ShowDialog();
                }
            }
            if (allReady)
            {
                //check if total > avance
                if (Convert.ToDouble(metroTextBox4.Text) >= Convert.ToDouble(metroTextBox3.Text))
                {
                    Classes.scheduler work = new Classes.scheduler();
                    work.addNew(metroTextBox1.Text, metroTextBox2.Text, metroTextBox3.Text, metroTextBox4.Text, metroDateTime1.Text);
                    MessageBox.Show("action effectué avec succès");
                    refresh();
                    init();
                }
                else
                    MessageBox.Show("Verifiez les montants entrés ");
            }
            else
                MessageBox.Show("Veuillez remplir toutes les cases");

        }
        void init()
        {
            metroTextBox1.Text = "";
            metroTextBox2.Text = "";
            metroTextBox3.Text = "";
            metroTextBox4.Text = "";
        }
        private void clientSelection(object sender, EventArgs e)
        {

            foreach(DataRow row in dtClients.Rows)
            {
                if(row.ItemArray[1].ToString().ToUpper()==metroTextBox1.Text.ToUpper())
                {
                    metroTextBox2.Text = row.ItemArray[2].ToString();
                }
            }

            updateProgress();
        }
    }
}
