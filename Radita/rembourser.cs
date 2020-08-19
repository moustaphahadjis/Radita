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
    public partial class rembourser : Form
    {
        string id, credit;
        public rembourser(string str1, string str2)
        {
            InitializeComponent();
            id = str1;
            credit = str2;
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
        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox3.Text))
            if (isNumber(textBox3.Text))
            {
                if (Convert.ToInt64(textBox3.Text) <= Convert.ToInt64(credit))
                {
                    double value = Convert.ToInt64(credit) - Convert.ToInt64(textBox3.Text);
                    Classes.Clients tmp = new Classes.Clients();
                    tmp.rembourser(id, value.ToString());
                }
                else
                {
                    MessageBox.Show("Le montant à rembouser est superieur au credit actuel");
                }
            }
            else
            {
                MessageBox.Show("Ce montant n'est pas valide");
            }
        }

        private void rembourser_Load(object sender, EventArgs e)
        {
            textBox1.Text = credit;
            Classes.design design = new Classes.design();
            button1 = design.button(button1);
        }
    }
}
