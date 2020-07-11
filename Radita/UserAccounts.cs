using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MySql.Data.MySqlClient;


namespace Radita
{
    public class UserAccounts
    {
        public string confirmedAdmin, confirmedLastName;
        private MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=radita");

        public bool CheckPass(string str1, string str2)
        {
            bool result;

            conn.Open();
            string checkPassword = "select admin, lastname from users where username='" + str1 + "' and password='" + str2 + "'";
            MySqlCommand cmd = new MySqlCommand(checkPassword, conn);
            MySqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                result = true;
                confirmedAdmin = sdr[0].ToString();
                confirmedLastName = sdr[1].ToString();
            }
            else
            {
                result = false;
            }
            conn.Close();
            return result;
        }

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
                MessageBox.Show("User has been created successfully");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Couldn't create user! " + ex.ToString());
            }
        }

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
                MessageBox.Show("Error! Failed to Delete! " + ex.ToString());
            }
        }

        public void Modify(string str1, string str2, string str3, string str4, string str5, string str6)
        {
            try
            {
                conn.Open();
                string mod = "update users set username='" + str1 + "', password='" + str2 + "', admin='" + str3 + "', lastname='" + str4 + "', firstname='" + str5 + "', secretword='" + str6 + "' where username='" + str1 + "'";
                MySqlCommand cmd = new MySqlCommand(mod, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! Failed to Update information! " + ex.ToString());
            }
        }
    }
}
