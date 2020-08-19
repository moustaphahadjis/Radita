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
    public partial class mainForm : Form
    {
        Form activeMiddleForm, activeRightForm;
        Login loginForm;
        public mainForm(Login login)
        {
            InitializeComponent();
            activeMiddleForm = null;
            activeRightForm = null;
            loginForm = login;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void changeRightPanel(Form form)
        {
            if (activeRightForm != null)
            {
                activeRightForm.Close();
            }
            activeRightForm = form;
            activeRightForm.FormBorderStyle = FormBorderStyle.None;
            activeRightForm.TopLevel = false;
            activeRightForm.Dock = DockStyle.Fill;
            panel13.Controls.Add(activeRightForm);
           
            activeRightForm.Show();
        }
        public void changeMiddlePanel(Form form)
        {
            if (activeMiddleForm != null)
            {
                activeMiddleForm.Close();
            }
            activeMiddleForm = form;
            activeMiddleForm.FormBorderStyle = FormBorderStyle.None;
            activeMiddleForm.TopLevel = false;
            activeMiddleForm.Dock = DockStyle.Fill;
            panel9.Controls.Add(activeMiddleForm);
            activeMiddleForm.Show();
            label8.Text = activeMiddleForm.Name.ToUpper();
        }
        void buttonHover(Panel panel)
        {
            try
            {
                panel.BackColor = Color.FromArgb(53, 53, 53);
                Cursor = Cursors.Hand;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        void buttonLeave(Panel panel)
        {
            try
            {
                panel.BackColor = panel1.BackColor;
                Cursor = Cursors.Default;
            }  
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            buttonHover(panel3);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            buttonLeave(panel3);
        }

        

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Click(object sender, EventArgs e)
        {
            changeMiddlePanel(new partenaire(this));
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            changeMiddlePanel(new couture(this));
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Close();
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeMiddlePanel(new boutiques(this));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changeMiddlePanel(new couture(this));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeMiddlePanel(new partenaire(this));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkPassword tmp = new checkPassword(loginForm.username);
            tmp.ShowDialog();
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            changeMiddlePanel(new boutiques(this));
        }
    }
}
