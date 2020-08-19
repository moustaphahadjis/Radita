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
            }
        }

        private void addContrat_Load(object sender, EventArgs e)
        {
            Classes.design design = new Classes.design();
            button1 = design.button(button1);
        }
    }
}
