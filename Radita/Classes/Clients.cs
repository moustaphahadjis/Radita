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
        public void Add(string str1, ulong num1, float flo1)
        {
            
            try
            {
                con.Open();
                string addClient = "insert into clients(names,telephone,credit,balance) values(@names,@telephone,@credit,@balance)";
                MySqlCommand cmd = new MySqlCommand(addClient, con);
                cmd.Parameters.AddWithValue("@names", str1);
                cmd.Parameters.AddWithValue("@telephone", num1);
                cmd.Parameters.AddWithValue("@credit", 0.0);
                cmd.Parameters.AddWithValue("@balance", flo1);
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

        /******Method to get balance******/
        public float GetBalance(string str1, ulong num1)
        {
            float result = 0;
            con.Open();
            string getBal = "select balance from clients where names='" + str1 + "' && telephone ='" + num1 + "'";
            MySqlCommand cmd = new MySqlCommand(getBal, con);
            MySqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                result = sdr.GetFloat(0);
            }
            else
            {
                MessageBox.Show("Error!");
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

        /******Method to deposit funds******/
        public void Deposit(string str1, ulong num1, float flo1)
        {
            try
            {
                con.Open();
                string mod = "update clients set balance='" + flo1 + "' where names='" + str1 + "' && telephone='" + num1 + "'";
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
