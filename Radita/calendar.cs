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
    
    public partial class calendar : Form
    {
        
        List<Button> digits;
        DataTable dtCalendar;
        public calendar()
        {
            InitializeComponent();
            digits = new List<Button>();
            dtCalendar = new DataTable();
            Classes.scheduler scheduler= new Classes.scheduler();
            dtCalendar = scheduler.getAll();
            initList();
        }

        void initList()
        {
            digits.Add(button1);
            digits.Add(button2);
            digits.Add(button3);
            digits.Add(button4);
            digits.Add(button5);
            digits.Add(button6);
            digits.Add(button7);
            digits.Add(button8);
            digits.Add(button9);
            digits.Add(button10);
            digits.Add(button11);
            digits.Add(button12);
            digits.Add(button13);
            digits.Add(button14);
            digits.Add(button15);
            digits.Add(button16);
            digits.Add(button17);
            digits.Add(button18);
            digits.Add(button19);
            digits.Add(button20);
            digits.Add(button21);
            digits.Add(button22);
            digits.Add(button23);
            digits.Add(button24);
            digits.Add(button25);
            digits.Add(button26);
            digits.Add(button27);
            digits.Add(button31);
            digits.Add(button32);
            digits.Add(button33);
            digits.Add(button34);
        }
        private void calendar_Load(object sender, EventArgs e)
        {
            //setting comboboxes values
            comboBox1.SelectedItem = comboBox1.Items[DateTime.Now.Month-1];
            for (int i = 0; i < 5; i++)
            {
                if (comboBox2.Items[i].ToString() == DateTime.Now.Year.ToString())
                    comboBox2.SelectedItem = comboBox2.Items[i];

            }

            
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
                        //choosing which digig to show
            if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text))
            {
                int days = DateTime.DaysInMonth(Convert.ToInt32(comboBox2.SelectedItem), comboBox1.SelectedIndex + 1);
                for (int i = 0; i < digits.Count; i++)
                {
                    if (Convert.ToInt32(digits[i].Text) <= days)
                    {
                        digits[i].Visible = true;
                        digits[i].Enabled = true;

                        for(int j=0; j<dtCalendar.Rows.Count;j++)
                        {
                            DateTime tmp1 = Convert.ToDateTime(dtCalendar.Rows[j].ItemArray[6].ToString());
                            DateTime tmp2 = new DateTime(Convert.ToInt32(comboBox2.SelectedItem), comboBox1.SelectedIndex + 1, i);

                            if (tmp1.Month == tmp2.Month && tmp1.Year == tmp2.Year && tmp1.Day == tmp2.Day)
                                digits[i].BackColor = Color.Blue;
                        }
                    }
                    else
                    {
                        digits[i].Visible = false;
                        digits[i].Enabled = false;
                    }
                }
            }
        }
    }
}
