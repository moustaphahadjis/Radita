using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Radita.Classes
{
    class Clients
    {
        private MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=radita");

        /******Method to add record to database******/
        public void Add(string name, string phone)
        {
            try
            {
                con.Open();
                string addClient = "insert into clients(names,telephone,type,total,credit,balance) values(@names,@telephone,@type,@total,@credit,@balance)";
                MySqlCommand cmd = new MySqlCommand(addClient, con);
                cmd.Parameters.AddWithValue("@names", name);
                cmd.Parameters.AddWithValue("@telephone", phone);
                cmd.Parameters.AddWithValue("@credit", "0.0");
                cmd.Parameters.AddWithValue("@balance", "0.0");
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }

        /******Method to check for client******/
        public bool CheckClient(string str1)
        {
            bool result;

            con.Open();
            string checkName = "select * from clients where names='" + str1 + "'";
            MySqlCommand cmd = new MySqlCommand(checkName, con);
            MySqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                result = true;
            }
            else
            {
                result = false;
            }
            con.Close();
            return result;
        }

        /******Method to delete record******/
        public void Delete(string str1)
        {
            try
            {
                con.Open();
                string del = "delete from clients where names='" + str1 + "'";
                MySqlCommand cmd = new MySqlCommand(del, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }

        /******Method to modify records******/
        public void Modify(string str0, string str1, string str2, string str3)
        {
            try
            {
                con.Open();
                string mod = "update clients set total='" + str1 + "', credit='" + str2 + "', balance='" + str3 + "' where id='" + str0 + "'";
                MySqlCommand cmd = new MySqlCommand(mod, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }

        public DataTable getAll()
        {
            try
            {
                con.Open();
                MySqlDataAdapter data = new MySqlDataAdapter("select * from clients", con);
                DataTable dt = new DataTable();
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
    }
}
