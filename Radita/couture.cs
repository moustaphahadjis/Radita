﻿using System;
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
    public partial class couture : Form
    {
        mainForm main;
        public couture(mainForm form)
        {
            InitializeComponent();
            main = form;
        }
        void buttonHover(Panel panel)
        {
            panel.BackColor = Color.FromArgb(184, 210, 218);
            Cursor = Cursors.Hand;
        }
        void buttonLeave(Panel panel)
        {
            panel.BackColor = Color.White;
            Cursor = Cursors.Default;
        }
        private void panel1_MouseHover(object sender, EventArgs e)
        {
            buttonHover(panel1);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            buttonLeave(panel1);
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            buttonHover(panel2);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            buttonLeave(panel2);
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            buttonHover(panel3);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            buttonLeave(panel3);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //main.changeRightPanel((Form)new coutureView());
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            main.changeRightPanel((Form)new calendar());
        }
    }
}