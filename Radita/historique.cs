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
    public partial class historique : Form
    {
        DataTable dt = new DataTable();
        public historique()
        {
            InitializeComponent();
        }

        private void historique_Load(object sender, EventArgs e)
        {
            Classes.historique tmp = new Classes.historique();
            dt = tmp.getAll();
            
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].HeaderText = "Noms";
            dataGridView1.Columns[3].HeaderText = "nombre";
            Classes.design design = new Classes.design();
            dataGridView1 = design.datagridview(dataGridView1);
        }
    }
}
