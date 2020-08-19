using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Radita.Classes
{
    class design
    {
        public design()
        {

        }

        public DataGridView datagridview(DataGridView data)
        {
            data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            data.AllowUserToAddRows = false;
            data.AllowUserToDeleteRows = false;
            //data.AutoSizeRowsMode= DataGridViewAutoSizeRowsMode.AllHeaders;
            data.MultiSelect = false;
            data.ReadOnly = true;
            data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
            data.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 212, 144);
            data.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            data.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.DefaultCellStyle.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            data.ColumnHeadersDefaultCellStyle.Font= new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            data.BorderStyle = BorderStyle.None;
            data.ForeColor= System.Drawing.Color.Black;
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //data.Columns[0].Visible = false;
            data.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            data.Columns["id"].Visible = false;
            data.RowHeadersVisible = false;
            data.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach(DataGridViewColumn col in data.Columns)
            {
                col.HeaderText = col.HeaderText.ToUpper();
            }
            return data;
        }

        public Button button(Button but)
        {
            but.BackColor= System.Drawing.Color.FromArgb(0, 212, 144);
            but.Font= new System.Drawing.Font("Mongolian Baiti", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            but.Cursor = Cursors.Hand;
            but.FlatStyle = FlatStyle.Flat;
            return but;
        }
    }
}
