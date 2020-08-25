using MetroFramework.Properties;
using Radita.Classes;
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
    public partial class addStock : Form
    {
        DataTable dt = new DataTable();
        Image image;
        int selectedID;
        byte[] imageByte;
        bool close;
        public addStock(bool val)
        {
            InitializeComponent();
            openFileDialog1.Filter = "Image (*.jpg, *.jpeg,*.jp2,*.jfif,*.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            close = val;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        void refresh()
        {
            Classes.stock tmp = new Classes.stock();
            dt = tmp.getAll();
            textBox1.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            foreach (DataRow row in dt.Rows)
            {
                textBox1.AutoCompleteCustomSource.Add(row.ItemArray[1].ToString());
            }
            Classes.design design = new Classes.design();
            button1 = design.button(button1);
            button2 = design.button(button2);

        }
        private void addStock_Load(object sender, EventArgs e)
        {
            refresh();
        }
        void search()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
                foreach (DataRow row in dt.Rows)
                {
                    if (textBox1.Text.ToUpper() == row.ItemArray[1].ToString().ToUpper())
                    {
                        selectedID = Convert.ToInt32(row.ItemArray[0].ToString());
                        textBox2.Text = row.ItemArray[2].ToString();
                        textBox3.Text = "1";
                        comboBox1.Text = row.ItemArray[5].ToString();

                        imageByte = (byte[])row.ItemArray[4];
                        imageFromByte(imageByte);
                        break;
                    }
                }
        }
        bool validated()
        {
            bool result = true;
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                result = false;
            else
            {
                foreach(char c in textBox2.Text)
                {
                    if(!char.IsDigit(c))
                    {
                        result = false;
                        break;
                    }    
                }
                foreach (char c in textBox3.Text)
                {
                    if (!char.IsDigit(c))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }
        //Overloaded function to make image out of bytes
        void imageFromByte(byte [] value)
        {
            //imageByte = Convert.FromBase64String(value);

            //Bitmap custom = new Bitmap(path);

            //File.WriteAllBytes(path, imageByte);

            image = (Image)(new ImageConverter().ConvertFrom(value));
            pictureBox1.BackgroundImage = image;

        }
        //here is the second one
        void imageFromPath(string value)
        {
            string path = Path.GetTempPath()+@"\tmp.JPG";
            try
            {
                FileStream file = new FileStream(value, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(file);

                imageByte = br.ReadBytes((int)file.Length);

                //File.WriteAllBytes(path, imageByte);
                file.Close();
                br.Close();
                image = Image.FromFile(value);
                //image.Save(path);
                pictureBox1.BackgroundImage = image;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow rowExist=dt.NewRow();
            if(validated())
            {
                Classes.stock tmp = new Classes.stock();
                bool exist = false;
                foreach(DataRow row in dt.Rows)
                {
                    if(row.ItemArray[1].ToString().ToUpper()==textBox1.Text.ToUpper())
                    {
                        exist = true;
                        rowExist = row;
                        break;
                    }
                }
                if(exist)
                {
                    double number = Convert.ToDouble(rowExist[3].ToString()) + Convert.ToInt64(textBox3.Text);
                    tmp.update(textBox1.Text, Convert.ToDouble(textBox2.Text), (float)number, imageByte, comboBox1.Text, selectedID);
                    if (close)
                        this.Close();
                }
                else
                {
                    tmp.addStock(textBox1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt64(textBox3.Text), imageByte, comboBox1.Text);
                    if (close)
                        this.Close();
                }

                refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;
                    imageFromPath(path);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
