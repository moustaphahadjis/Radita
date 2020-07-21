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
        public void Add(string str1, string str2, string str3)
        {
            try
            {
                con.Open();
                string addClient = "insert into clients(names,telephone,type,total,credit,balance) values(@names,@telephone,@type,@total,@credit,@balance)";
                MySqlCommand cmd = new MySqlCommand(addClient, con);
                cmd.Parameters.AddWithValue("@names", str1);
                cmd.Parameters.AddWithValue("@telephone", str2);
                cmd.Parameters.AddWithValue("@type", str3);
                cmd.Parameters.AddWithValue("@total", "0.0");
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
        public void Modify(string str0, string str1, string str2, string str3, string str4, string str5, string str6)
        {
            try
            {
                con.Open();
                string mod = "update clients set names='" + str1 + "', telephone='" + str2 + "', total='" + str3 + "', credit='" + str4 + "', type='" + str5 + "', balance='" + str6 + "' where id='" + str0 + "'";
                MySqlCommand cmd = new MySqlCommand(mod, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }
    }
}
