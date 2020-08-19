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
    public partial class checkPassword : Form
    {
        public checkPassword(string username)
        {
            InitializeComponent();
            textBox1.Text = username;
        }

        private void checkPassword_Load(object sender, EventArgs e)
        {
            Classes.design design = new Classes.design();
            button1 = design.button(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.Users tmp = new Classes.Users();
            if (tmp.CheckPass(textBox1.Text, textBox2.Text))
            {
                DataTable dt = new DataTable();
                dt = tmp.getInfo(textBox1.Text, textBox2.Text);
                UpdateUser user = new UpdateUser(dt.Rows[0].ItemArray[0].ToString(),
                    dt.Rows[0].ItemArray[1].ToString(),
                    dt.Rows[0].ItemArray[2].ToString(),
                    dt.Rows[0].ItemArray[3].ToString(),
                    dt.Rows[0].ItemArray[5].ToString());

                user.Load += (s, args) => this.Close();
                user.ShowDialog();

               }
            else
                MessageBox.Show("Mot de passe incorrect");
        }
    }
}
