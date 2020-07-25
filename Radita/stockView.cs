using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radita
{
    public partial class stockView : Form
    {

        DataTable dtStock;
        public stockView()
        {
            InitializeComponent();
            dtStock = new DataTable();
        }

        DataTable createImage(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                byte[] bytes = (byte[])row.ItemArray[4];
                Bitmap bitmap;
                var ms = new MemoryStream(bytes);
                bitmap = new Bitmap(ms);
                row[6] = bitmap;
            }
            return dt;
        }
        private void stockView_Load(object sender, EventArgs e)
        {
            Classes.stock stock = new Classes.stock();
            dtStock = stock.getAll();
            
            dataGridView1.DataSource = dtStock;
            
        }
    }
}
