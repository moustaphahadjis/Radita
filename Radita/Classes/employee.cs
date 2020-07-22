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
    class employee
    {
        MySqlConnection con;
        MySqlCommand cmd;
        public employee()
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
                MySqlDataAdapter data = new MySqlDataAdapter("select * from employee", con);
                con.Close();
                data.Fill(dt);
                return dt;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public void modify(int id, string name, string phone, string employe)
        {
            //Modify details by only using the ID
            try
            {
                con.Open();

                cmd = new MySqlCommand("update scheduler set name='" + name + "', telephone='" + phone+"'where id='" + id + "'", con);
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void remove(int id)
        {
            try
            {
                con.Open();

                cmd = new MySqlCommand("delete from employee where id ='" + id + "'", con);
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void addNew(string name, string phone)
        {
            try
            {
                con.Open();

                cmd = new MySqlCommand("Insert into scheduler (name, telephone) values('" + name + "','" + phone + "')", con);
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

    }
}
