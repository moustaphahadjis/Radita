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

    
    class historique
    {
        MySqlConnection con;
        MySqlCommand cmd;
        public historique()
        {
            con = new MySqlConnection("database= radita; port=3306; datasource= localhost; username=root; password=;");
            con.Close();
        }

        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                MySqlDataAdapter data = new MySqlDataAdapter("select * from historique", con);
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
        public void addNew(string name, string total, string client)
        {
            try
            {
                con.Open();

                cmd = new MySqlCommand("Insert into historique (name, total, client) values('" + name + "','" + total + "','" + client + "')", con);
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
