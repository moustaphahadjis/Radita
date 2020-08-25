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
        string a, b, c, d, ee, id, f;
        public modifierContrat(string ID,string tmp1, string tmp2, string tmp3, string tmp4, string tmp5, string tmp6)
        {
            InitializeComponent();
            a = tmp1;
            b = tmp2;
            c = tmp3;
            d = tmp4;
            ee = tmp5;
            id = ID;
            f = tmp6;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            reste();
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
        void reste()
        {
            if(!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
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
        private void modifierContrat_Load(object sender, EventArgs e)
        {
           
                textBox1.Text = a;
                textBox2.Text = b;
                textBox3.Text = c;
                textBox4.Text = d;
                textBox5.Text = ee;
                //dateTimePicker1.Value. = Convert.ToDateTime();

            
            Classes.design design = new Classes.design();
            button1 = design.button(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isOk())
            {
                Classes.scheduler tmp = new Classes.scheduler();
                tmp.modify(Convert.ToInt32(id), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value.ToString());

            }
        }
    }
}
