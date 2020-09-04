using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radita
{
    public partial class addContrat : Form
    {
        public addContrat()
        {
            InitializeComponent();
        }
        bool isNumber(string tmp)
        {
            bool result = true;
            for (int i = 0; i < tmp.Length; i++)
            {
                if (!char.IsDigit(tmp[i]))
                    result = false;
            }
            return result;
        }
        void reste()
        {
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                if (isNumber(textBox3.Text) && isNumber(textBox4.Text))
                {
                    double val = Convert.ToDouble(textBox4.Text) - Convert.ToDouble(textBox3.Text);
                    textBox5.Text = val.ToString();
                }
                else
                    textBox5.Text = "0";
            }
            else
                textBox5.Text = "0";
        }
        bool isOk()
        {
            bool r = true;
            if (!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(textBox2.Text) || !string.IsNullOrEmpty(textBox3.Text) || !string.IsNullOrEmpty(textBox4.Text) || !string.IsNullOrEmpty(textBox5.Text))
            {
                if (isNumber(textBox2.Text) && isNumber(textBox3.Text) && isNumber(textBox4.Text) && isNumber(textBox5.Text) )
                    r = true;
                else
                    r = false;

            }
            else
                r = false;


            return r;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(isOk())
            {
                Classes.scheduler tmp = new Classes.scheduler();
                tmp.addNew(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value.ToString());
                MessageBox.Show("Action éffectue avec succès");
                this.Close();
            }
        }

        DataTable dt;
        private void addContrat_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            Classes.Clients tmp = new Classes.Clients();
            dt = tmp.getAll();

            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            textBox2.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                textBox1.AutoCompleteCustomSource.Add(row.ItemArray[1].ToString());
                textBox2.AutoCompleteCustomSource.Add(row.ItemArray[1].ToString());
            }
            Classes.design design = new Classes.design();
            button1 = design.button(button1);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            reste();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row.ItemArray[1].ToString().ToUpper() == textBox1.Text.ToUpper())
                {
                    textBox2.Text = row.ItemArray[2].ToString();
                    break;
                }
            }
        }
    }
}
