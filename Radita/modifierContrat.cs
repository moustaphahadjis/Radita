using Org.BouncyCastle.Asn1.Cms;
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
    public partial class modifierContrat : Form
    {
        DataGridViewRow row;
        public modifierContrat(DataGridViewRow tmp)
        {
            InitializeComponent();
            row = tmp;
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
        private void modifierContrat_Load(object sender, EventArgs e)
        {
            if (isOk())
            {
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells[6].Value.ToString());

            }
            Classes.design design = new Classes.design();
            button1 = design.button(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.scheduler tmp = new Classes.scheduler();
            tmp.modify(Convert.ToInt32(row.Cells[0].Value.ToString()), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value.ToString());
        }
    }
}
