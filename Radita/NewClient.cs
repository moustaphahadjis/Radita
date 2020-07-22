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
    public partial class NewClient : Form
    {
        string name, phone;
        public NewClient()
        {
            InitializeComponent();
            name = "";
            phone = "";
        }
        //overloading constructor to get Name and Phone NUmber
        public NewClient(string tmp1, string tmp2)
        {
            InitializeComponent();
            name = tmp1;
            phone = tmp2;

            textBox1.Text = name;
            textBox2.Text = phone;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.Clients temp = new Classes.Clients();
            bool exist = false;

            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                exist = temp.CheckClient(textBox1.Text);
                if (exist == false)
                {
                    temp.Add(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString());
                    MessageBox.Show("Client has been added successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Client already exists!");
                }
            }
            else
            {
                MessageBox.Show("Please fill in empty field(s)!");
            }
        }
    }
}