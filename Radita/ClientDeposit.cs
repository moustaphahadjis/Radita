using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Radita
{
    public partial class ClientDeposit : Form
    {
        string nom, telephone,id;
        bool close;
        public ClientDeposit(string Id,string Nom, string Telephone,bool Close)
        {
            InitializeComponent();
            nom = Nom;
            telephone = Telephone;
            id = Id;
            close = Close;
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
            Classes.Clients temp = new Classes.Clients();
            float val = 0;
            ulong phone = 0;

            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                if (isNumber(textBox2.Text) == true)
                {
                    try
                    {
                        phone = Convert.ToUInt64(textBox2.Text);

                        val = temp.GetBalance(id);
                        val += float.Parse(textBox3.Text);
                        temp.Deposit(textBox1.Text, phone, val);

                        Classes.historiquePartenaire part = new Classes.historiquePartenaire();
                        part.addNew(nom, telephone, "Dépôt", textBox3.Text);
                        MessageBox.Show("Dépôt éffectué avec succès");
                        if (close)
                        {
                            this.Close();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Valeur invalide");
                }
                
            }
        }

        private void ClientDeposit_Load(object sender, EventArgs e)
        {
            textBox1.Text = nom;
            textBox2.Text = telephone;
            Classes.design design = new Classes.design();
            button1 = design.button(button1);
        }
    }
}
