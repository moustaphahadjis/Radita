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
            Classes.scheduler scheduler = new Classes.scheduler();
            dtCalendar = scheduler.getAll();
            initList();
            initButtons();

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
        void refresh()
        {
            //setting comboboxes values
            comboBox1.SelectedItem = comboBox1.Items[DateTime.Now.Month - 1];
            for (int i = 0; i < 5; i++)
            {
                if (comboBox2.Items[i].ToString() == DateTime.Now.Year.ToString())
                    comboBox2.SelectedItem = comboBox2.Items[i];

            }
                dataGridView1.Columns.Add("id", "id");
                dataGridView1.Columns.Add("1", "Client");
                dataGridView1.Columns.Add("2", "Telephone");
                dataGridView1.Columns.Add("3", "Avance");
                dataGridView1.Columns.Add("4", "Total");
                dataGridView1.Columns.Add("5", "Reste");
                dataGridView1.Columns.Add("6", "Date");
            Classes.design design = new Classes.design();
            dataGridView1 = design.datagridview(dataGridView1);
            button28 = design.button(button28);
        }
        void init()
        {

            if (dataGridView1.Rows.Count > 0)
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                }
            dtCalendar = new DataTable();
            Classes.scheduler scheduler = new Classes.scheduler();
            dtCalendar = scheduler.getAll();
        }
        private void calendar_Load(object sender, EventArgs e)
        {
            refresh();
            //initButtons();
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
        void initButtons()
        {
            //choosing which digit to show
            if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text))
            {
                if (isNumber(comboBox2.Text))
                {

                    int days = DateTime.DaysInMonth(Convert.ToInt32(comboBox2.SelectedItem), comboBox1.SelectedIndex + 1);
                    for (int i = 0; i < digits.Count; i++)
                    {
                        if (Convert.ToInt32(digits[i].Text) < days)
                        {
                            digits[i].Visible = true;
                            digits[i].Enabled = true;
                            digits[i].BackColor = Color.White;

                            for (int j = 0; j < dtCalendar.Rows.Count; j++)
                            {
                                DateTime tmp1 = Convert.ToDateTime(dtCalendar.Rows[j].ItemArray[6].ToString());
                                DateTime tmp2 = new DateTime(Convert.ToInt32(comboBox2.Text), comboBox1.SelectedIndex + 1, Convert.ToInt32(digits[i].Text));

                                //if (tmp1.Month == tmp2.Month && tmp1.Year == tmp2.Year && tmp1.Day == tmp2.Day)
                                if (tmp1.Year==tmp2.Year && tmp1.Month==tmp2.Month && tmp1.Day==tmp2.Day)
                                {
                                    digits[i].BackColor = System.Drawing.Color.FromArgb(0, 212, 144);
                                }
                                //else
                                //digits[i].BackColor = Color.Transparent;
                            }
                        }
                        else
                        {
                            digits[i].Visible = false;
                            digits[i].Enabled = false;
                            digits[i].BackColor = Color.White;
                        }

                    }
                }
            }
        }
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            initButtons();
        }

        void btnClick(Button btn)
        {
            //Reset datagridview
            if (dataGridView1.Rows.Count > 0)
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }

            //Adding rows to DatagridView
            foreach (DataRow row in dtCalendar.Rows)
            {
                DateTime time = new DateTime(Convert.ToInt32(comboBox2.Text), comboBox1.SelectedIndex + 1, Convert.ToInt32(btn.Text));
                DateTime time2 = Convert.ToDateTime(row[6].ToString());
                if (time.Month == time2.Month && time.Year == time2.Year && time.Day == time2.Day)
                {

                    dataGridView1.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
                }
            }

        }

        private void button34_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btnClick(btn);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        bool validRow()
        {
            bool r = false;
            if (dataGridView1.Rows.Count > 0)
                if (dataGridView1.SelectedRows.Count > 0)
                    if (dataGridView1.SelectedRows[0] != null)
                        r = true;
            return r;
        }
        private void button28_Click(object sender, EventArgs e)
        {
            if (validRow())
            {
                if (Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[5].Value.ToString()) >= 0)
                {
                    if (MessageBox.Show("Il reste " + dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + " à payer \nContinuer?", "Completer cetter transaction", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Classes.historiqueCouture tmp = new Classes.historiqueCouture();
                        tmp.addNew(dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), "Payé");
                        Classes.scheduler tmp2 = new Classes.scheduler();
                        tmp2.remove(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                        this.init();
                        this.initButtons();
                    }
                }
            }
        }
    }
}
