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

        void refresh()
        {
            Classes.stock tmp = new Classes.stock();
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

            Classes.design design = new Classes.design();
            button1 = design.button(button1);
            button2 = design.button(button2);
            button3 = design.button(button3);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            refresh();
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

                        textBox1.Text= row.ItemArray[2].ToString();
                        textBox2.Text = "1";
                        label9.Text = row[5].ToString();
                        //string val= new ByteConverter().ConvertFrom(row[4]).ToString();
                        imageFromByte((byte[])row[4]);
                        break;
                    }
                }
            }
        }
        void imageFromByte(Byte []value)
        {
            
            //string path = Path.GetTempPath() + @"\tmp.JPG";
            //imageByte = Convert.FromBase64String(value);

            //Bitmap custom = new Bitmap(path);

            //File.WriteAllBytes(path, imageByte);

            image = (Image)(new ImageConverter().ConvertFrom(value));
            pictureBox1.BackgroundImage = image;

            image = null;
            imageByte = null;
            
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                if(isNumber(textBox1.Text) && isNumber(textBox2.Text))
                {
                    textBox3.Text = (Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text)).ToString();
                }
                else
                    textBox3.Text = "0";
            }
            else
                textBox3.Text = "0";
        }

        
        bool allOk()
        {
            bool r = true;
            
            if((Convert.ToInt32(textBox3.Text)>= Convert.ToInt32(label2.Text)))
            {
                MessageBox.Show("Le nombre validé est superieur au nombre present en stock");
                r = false;
            }
            if(string.IsNullOrEmpty(textBox3.Text) || textBox3.Text=="0")
            {
                MessageBox.Show("Verifiez les informations validées");
                r = false;
            }
            if(string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Vous n'avez pas selectioné de client");
                r = false;
            }

            return r;
        }

        string id;
        bool clientExist()
        {
            bool r = false;
            foreach(DataRow row in dtClient.Rows)
            {
                if(row[1].ToString().ToUpper()==textBox4.Text.ToUpper())
                {
                    r = true;
                    id = row[0].ToString();
                    break;
                }
            }
            if(!r)
            {
                DialogResult dialog = MessageBox.Show("Voulez vous Ajouter ce Client?", "Nouveau Client", MessageBoxButtons.YesNo);
                if(dialog== DialogResult.Yes)
                {
                    newClient tmp = new newClient(textBox4.Text,"",true);
                    tmp.Closed += (s, args) => this.refresh();
                    tmp.ShowDialog();
                }
            }
            return r;
        }
        float clientMoney;
        bool hasMoney(string id)
        {
            Classes.Clients tmp = new Classes.Clients();
            clientMoney = tmp.GetBalance(id);
            if (clientMoney >= Convert.ToInt64(textBox4.Text))
            {
                return true;
            }
            else
                return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(allOk())
            {
                if (clientExist())
                {
                    Classes.historique tmp = new Classes.historique();
                    tmp.addNew(label3.Text, textBox3.Text, textBox2.Text, textBox4.Text, button1.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (allOk())
            {
                if (clientExist())
                {
                    Classes.Clients client = new Classes.Clients();
                    client.addCredit(id, textBox3.Text);
                    Classes.historique tmp = new Classes.historique();
                    tmp.addNew(label3.Text, textBox3.Text, textBox2.Text, textBox4.Text, button2.Text);
                
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(allOk())
            {
                if(clientExist())
                {
                    if (hasMoney(id))
                    {
                        Classes.Clients client = new Classes.Clients();
                        string val = (clientMoney - Convert.ToInt64(textBox3.Text)).ToString();
                        client.addBalance(id, val);
                        Classes.historique tmp = new Classes.historique();
                        tmp.addNew(label3.Text, textBox3.Text, textBox2.Text, textBox4.Text, button2.Text);

                    }
                    else
                        MessageBox.Show("Ce Client n'a que " + clientMoney.ToString() + " dans son compte");
                }
            }
        }
    }
}
