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

        public mainForm()
        {
            InitializeComponent();
            activeMiddleForm = null;
            activeRightForm = null;
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
            panel.BackColor=Color.FromArgb(53, 53, 53);
            Cursor = Cursors.Hand;
        }
        void buttonLeave(Panel panel)
        {
            panel.BackColor = panel1.BackColor;
            Cursor=Cursors.Default;
        }

        private void panel12_MouseHover(object sender, EventArgs e)
        {
            buttonHover(panel12);
        }

        private void panel12_MouseLeave(object sender, EventArgs e)
        {
            buttonLeave(panel12);
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            buttonHover(panel12);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            buttonLeave(panel12);
        }

        private void panel7_MouseHover(object sender, EventArgs e)
        {
            buttonHover(panel7);
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            buttonLeave(panel7);
        }

        private void panel8_MouseHover(object sender, EventArgs e)
        {
            buttonHover(panel8);
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            buttonLeave(panel8);
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            buttonHover(panel3);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            buttonLeave(panel3);
        }

        private void panel6_MouseHover(object sender, EventArgs e)
        {
            buttonHover(panel6);
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            buttonLeave(panel6);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Click(object sender, EventArgs e)
        {
            changeMiddlePanel(new boutiques(this));
        }
    }
}
