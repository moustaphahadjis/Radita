using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Radita.Classes
{
    class stock
    {
        MySqlConnection con;
        MySqlCommand cmd;

        public stock()
        {
            con = new MySqlConnection("database=radita; port=3306; username=root; password=; datasource= localhost;");
            con.Close();
        }

        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                MySqlDataAdapter data = new MySqlDataAdapter("select * from stock",con);
                data.Fill(dt);
                con.Close();
                return dt;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public void addStock(string name, double price, float number, byte[] picture)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("Insert into stock (name,price,number,picture) values('" + name + "','" + price + "','" + number + "','" + picture + "')", con);
                con.Close();

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public DataTable getItem(string name)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                MySqlDataAdapter data= new MySqlDataAdapter("select * from stock where name= '" + name + "'", con);
                data.Fill(dt);
                con.Close();
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