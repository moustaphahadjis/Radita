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
            string searchVal = metroTextBox4.Text;
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
            Classes.stock temp = new Classes.stock();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    temp.delete(row.Cells[1].Value.ToString());
                    dtStock = temp.getAll();
                }
                MessageBox.Show("Record(s) deleted Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)  
        {
            Classes.stock temp = new Classes.stock();
            bool exist = false;

            if (metroTextBox1.Text.Trim() != "" && metroTextBox2.Text.Trim() != "" && metroTextBox3.Text.Trim() != "")
            {
                if(isNumber(metroTextBox2.Text) == true && isNumber(metroTextBox3.Text) == true){
                    exist = temp.CheckItem(metroTextBox1.Text);
                    if (exist == false)
                    {
                        temp.addStock(metroTextBox1.Text, Convert.ToDouble(metroTextBox2.Text), float.Parse(metroTextBox3.Text));
                        MessageBox.Show("User has been created successfully");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("User already exists!");
                    }
                }   
            }
            else
            {
                MessageBox.Show("Please fill in empty field(s)!");
            }
        }
    }
}
