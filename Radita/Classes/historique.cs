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
            Classes.connection c = new Classes.connection();
            con = c.getCon();
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
        public bool addNew(string name, string total,string num, string client, string type)
        {
            try
            {
                con.Open();

                cmd = new MySqlCommand("Insert into historique (name, total, number, client, type,date) values('" + name + "','" + total + "','" + num + "','" + client + "','" + type + "','" + DateTime.Now.ToString() + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
    }
}
