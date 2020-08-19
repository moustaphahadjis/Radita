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
    public partial class historiqueCouture : Form
    {
        public historiqueCouture()
        {
            InitializeComponent();
        }

        private void historiqueCouture_Load(object sender, EventArgs e)
        {
            Classes.design design = new Classes.design();
            dataGridView1 = design.datagridview(dataGridView1);
        }
    }
}
