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
    class Users
    {
        private MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=radita");

        /******Method to check user password******/
        public bool CheckPass(string str1, string str2)
        {
            bool result;

            conn.Open();
            string checkPassword = "select * from users where username='" + str1 + "' and password='" + str2 + "'";
            MySqlCommand cmd = new MySqlCommand(checkPassword, conn);
            MySqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                result = true;
            }
            else
            {
                result = false;
            }
            conn.Close();
            return result;
        }

        /******Method to check for user******/
        public bool CheckUser(string str1)
        {
            bool result;

            conn.Open();
            string checkUsername = "select * from users where username='" + str1 + "'";
            MySqlCommand cmd = new MySqlCommand(checkUsername, conn);
            MySqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                result = true;
            }
            else
            {
                result = false;
            }
            conn.Close();
            return result;
        }

        /******Method to add record to database******/
        public void Add(string str1, string str2, string str3, string str4, string str5, string str6)
        {
            try
            {
                conn.Open();
                string addUser = "insert into users(username,password,admin,lastname,firstname,secretword) values(@username,@password,@admin,@lastname,@firstname,@secretword)";
                MySqlCommand cmd = new MySqlCommand(addUser, conn);
                cmd.Parameters.AddWithValue("@username", str1);
                cmd.Parameters.AddWithValue("@password", str2);
                cmd.Parameters.AddWithValue("@admin", str3);
                cmd.Parameters.AddWithValue("@lastname", str4);
                cmd.Parameters.AddWithValue("@firstname", str5);
                cmd.Parameters.AddWithValue("@secretword", str6);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }

        /******Method to delete record******/
        public void Delete(string str1)
        {
            try
            {
                conn.Open();
                string del = "delete from users where username='" + str1 + "'";
                MySqlCommand cmd = new MySqlCommand(del, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
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
                conn.Open();
                string mod = "update users set username='" + str1 + "', password='" + str2 + "', admin='" + str3 + "', lastname='" + str4 + "', firstname='" + str5 + "', secretword='" + str6 + "' where id='" + str0 + "'";
                MySqlCommand cmd = new MySqlCommand(mod, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }
        public DataTable getInfo(string username, string pass)
        {

            try
            {
                conn.Open();
                MySqlDataAdapter cmd = new MySqlDataAdapter("select * from users where username='" + username + "' and password='" + pass + "'", conn);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
                return null;
            }
        }
        public void Modify(string id,string name, string prenom, string username, string password, string mot)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update users set username='" + username + "', password='" + password + "', lastname='" + prenom + "', firstname='" + name + "', secretword='" + mot + "' where id='" + id + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }
    }
}
