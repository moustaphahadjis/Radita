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
    public partial class newWork : MetroFramework.Forms.MetroForm
    {
        int progressCounter;
        bool allready;
        public newWork()
        {
            InitializeComponent();
            progressCounter = 0;
            allready = false;
        }

        private void newWork_Load(object sender, EventArgs e)
        {

        }

        void refresh()
        {
            DataTable clients, employees;
            //adding clients and employees to autocomplete;
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
            if (!string.IsNullOrEmpty(metroComboBox1.Text))
            {
                counter++;
            }
            if (metroDateTime1.Value.CompareTo(DateTime.Now) >= 0)
            {
                counter++;
            }

            progressCounter = counter;

            int progressSplit = 100 / 6;

            switch (progressCounter)
            {
                case 1:
                    metroProgressSpinner1.Value = progressSplit;
                    allready = false;
                    break;
                case 2:
                    metroProgressSpinner1.Value = progressSplit * 2;
                    allready = false;
                    break;
                case 3:
                    metroProgressSpinner1.Value = progressSplit * 3;
                    allready = false;
                    break;
                case 4:
                    metroProgressSpinner1.Value = progressSplit * 4;
                    allready = false;
                    break;
                case 5:
                    metroProgressSpinner1.Value = progressSplit * 5;
                    allready = false;
                    break;
                case 6:
                    metroProgressSpinner1.Value = progressSplit * 6;
                    allready = true;
                    break;
                default:
                    metroProgressSpinner1.Value = 0;
                    allready = false;
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
            if (!string.IsNullOrEmpty(metroComboBox1.Text))
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
    }
}
