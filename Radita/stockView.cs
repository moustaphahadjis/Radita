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

        void createImage(DataGridView dt)
        {
            DataGridViewImageColumn column = new DataGridViewImageColumn();
            column.ImageLayout = DataGridViewImageCellLayout.Stretch;
            column.Dispose();
            dt.Columns.Add(column);
            foreach (DataGridViewRow row in dt.Rows)
            {
                
                if (!String.IsNullOrEmpty(row.Cells[4].Value.ToString()))
                {
                    
                    byte[] bytes = Convert.FromBase64String(row.Cells[4].Value.ToString());
                    Image image;
                    image = (Bitmap)(new ImageConverter().ConvertFrom(bytes));
                    
                    //row.Cells[4].ValueType = new DataGridViewImageCell();
                    row.Cells[6].Value = image;
                }
            }
        }
        void refresh()
        {
            Classes.stock stock = new Classes.stock();
            dtStock = stock.getAll();
            dataGridView1.DataSource = dtStock;

            dataGridView1.Columns[1].HeaderText = "noms";
            dataGridView1.Columns[2].HeaderText = "Prix";
            dataGridView1.Columns[3].HeaderText = "Nombre";
            dataGridView1.Columns[4].HeaderText = "Image";
            dataGridView1.Columns[5].HeaderText = "Unité";
            Classes.design design = new Classes.design();
            dataGridView1 = design.datagridview(dataGridView1);
            //dataGridView1.Size = new Size(dataGridView1.Size.Width, 50);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col is DataGridViewImageColumn)
                    ((DataGridViewImageColumn)(col)).ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
            
            button1 = design.button(button1);
            button2 = design.button(button2);
            button3 = design.button(button3);

            //Search bar
            metroTextBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            metroTextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            metroTextBox1.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            foreach (DataRow row in dtStock.Rows)
            {
                metroTextBox1.AutoCompleteCustomSource.Add(row[1].ToString());
            }
            //createImage(dataGridView1);
        }
        private void stockView_Load(object sender, EventArgs e)
        {
            refresh();
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
            string searchVal = metroTextBox1.Text;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ClearSelection();

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(searchVal))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez Vous vraiment supprimer cet article?", "Supprimer", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Classes.stock temp = new Classes.stock();
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        temp.delete(row.Cells[1].Value.ToString());
                        dtStock = temp.getAll();
                        refresh();
                    }
                    MessageBox.Show("Cet article a été supprimé!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)  
        {
            Form a1 = new addStock(true);

            a1.Closed += (s, args) => this.refresh();
            
            a1.ShowDialog();
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().ToUpper() == metroTextBox1.Text.ToUpper())
                    {
                        row.Selected = true;
                        break;
                    }
                }
        }
    }
}
