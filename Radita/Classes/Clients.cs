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
        MySqlConnection con;
        public Clients()
        {
            Classes.connection c = new Classes.connection();
            con = c.getCon();
        }
        /******Method to add record to database******/
        public void Add(string str1, ulong num1)
        {

            try
            {
                con.Open();
                string addClient = "insert into clients(name,telephone,credit,balance) values(@names,@telephone,@credit,@balance)";
                MySqlCommand cmd = new MySqlCommand(addClient, con);
                cmd.Parameters.AddWithValue("@names", str1);
                cmd.Parameters.AddWithValue("@telephone", num1);
                cmd.Parameters.AddWithValue("@credit", 0);
                cmd.Parameters.AddWithValue("@balance", 0);
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
            string checkName = "select * from clients where name='" + str1 + "'";
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
        public float GetBalance(string id)
        {
            float result = 0;
            con.Open();
            string getBal = "select balance from clients where id='" + id+"'";
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
        public void Delete(string id)
        {
            try
            {
                con.Open();
                string del = "delete from clients where id='" + id + "'";
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
                string mod = "update clients set balance='" + flo1 + "' where name='" + str1 + "' && telephone='" + num1 + "'";
                MySqlCommand cmd = new MySqlCommand(mod, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }
        public void rembourser(string id, string montant)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Update clients set credit=" + montant + " where id=" + id + "", con);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
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
        public bool addBalance(string id, string balance)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Update clients set balance = '" + balance + "' where id='" + id + "'", con);
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
        public bool addCredit(string id,string credit)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select credit from clients where id='" + id + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    credit = (Convert.ToDouble(credit) + reader.GetDouble(0)).ToString();
                }
                reader.Close();
                cmd = new MySqlCommand("update clients set credit='" + credit + "' where id='" + id + "'", con);
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
        public void Add(string name, string telephone, string credit, string balance)
        {

            try
            {
                con.Open();
                string addClient = "insert into clients(name,telephone,credit,balance) values(@names,@telephone,@credit,@balance)";
                MySqlCommand cmd = new MySqlCommand(addClient, con);
                cmd.Parameters.AddWithValue("@names", name);
                cmd.Parameters.AddWithValue("@telephone", telephone);
                cmd.Parameters.AddWithValue("@credit", credit);
                cmd.Parameters.AddWithValue("@balance", balance);
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
