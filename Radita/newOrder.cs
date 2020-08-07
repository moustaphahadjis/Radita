using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MetroFramework;

namespace Radita
{
    public partial class newOrder : Form
    {
        DataTable dt = new DataTable();
        DataTable dtClient = new DataTable();
        byte[] imageByte;
        Image image;
        public newOrder()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Classes.stock tmp= new Classes.stock();
            Classes.Clients tmp2 = new Classes.Clients();
            dt = tmp.getAll();
            dtClient = tmp2.getAll();
            metroTextBox1.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            textBox4.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            
            foreach (DataRow row in dtClient.Rows)
            {
                textBox4.AutoCompleteCustomSource.Add(row.ItemArray[1].ToString());
            }
            foreach (DataRow row in dt.Rows)
            {
                metroTextBox1.AutoCompleteCustomSource.Add(row.ItemArray[1].ToString());
            }
        }
        void search()
        {
            if(!string.IsNullOrEmpty(metroTextBox1.Text))
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (metroTextBox1.Text.ToUpper() == row.ItemArray[1].ToString().ToUpper())
                    {
                        label1.Text = row.ItemArray[2].ToString();
                        label2.Text = row.ItemArray[3].ToString();
                        label3.Text = row.ItemArray[1].ToString();
                        imageFromByte(row[4].ToString());
                        break;
                    }
                }
            }
        }
        void imageFromByte(string value)
        {
            
            //string path = Path.GetTempPath() + @"\tmp.JPG";
            imageByte = Convert.FromBase64String(value);

            //Bitmap custom = new Bitmap(path);

            //File.WriteAllBytes(path, imageByte);

            image = (Bitmap)(new ImageConverter().ConvertFrom(imageByte));
                pictureBox1.BackgroundImage = image;
            
        }
        bool validated()
        {
            bool result = true;
            if (Convert.ToInt32(label2.Text) < Convert.ToInt32(textBox2.Text))
                result = false;
            if (Convert.ToInt32(textBox2.Text) <= 0)
                result = false;
            if (Convert.ToInt32(textBox1.Text) <= 0)
                result = false;

            return result;
        }
        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
