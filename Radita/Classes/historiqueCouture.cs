using System;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radita.Classes
{
    class historiqueCouture
    {
        MySqlConnection con;
        MySqlCommand cmd;
        public historiqueCouture()
        {
            Classes.connection c = new Classes.connection();
            con = c.getCon();

        }

        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                MySqlDataAdapter data = new MySqlDataAdapter("select * from historiqueCouture", con);
                con.Close();
                data.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
        public void addNew(string client,string telephone, string total, string type)
        {
            try
            {
                con.Open();

                cmd = new MySqlCommand("Insert into historiqueCouture (client, telephone, total,type, date) values('" + client + "','" + telephone + "','" + total + "', '"+type+"','"+DateTime.Now.ToString()+"')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}

