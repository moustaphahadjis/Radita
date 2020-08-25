using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

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
            try
            {
                con.Open();
                MySqlDataAdapter data = new MySqlDataAdapter("select * from stock", con);
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
        public DataTable getAllllll()
        {
            DataTable dt = new DataTable();
            
            for(int i=0; i<6;i++)
                dt.Columns.Add();
            
            MySqlDataReader data;
            try
            {
                con.Open();
                cmd= new MySqlCommand("select * from stock",con);

                data=cmd.ExecuteReader();
                while(data.Read())
                {
                    DataRow row = dt.NewRow();
                    row[0] = data[0];
                    row[1] = data[1];
                    row[2] = data[2];
                    row[3] = data[3];
                    byte[] tmp = (byte [])data[4];
                    row[4] = Convert.ToBase64String(tmp);
                    row[5] = data[5];

                    dt.Rows.Add(row);
                }
                con.Close();
                return dt;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public void addStock(string name, double price, float number, byte[] picture,string unite)
        {
            try
            {
                con.Open();
                if (picture != null)
                {
                    cmd = new MySqlCommand("Insert into stock (name,price,number,picture,unite) values('" + name + "','" + price + "','" + number + "',@picture,'" + unite + "')", con);

                    cmd.Parameters.Add("@picture", MySqlDbType.LongBlob, (int)picture.Length);
                    cmd.Parameters["@picture"].Value = picture;
                }
                else
                {
                    cmd = new MySqlCommand("Insert into stock (name,price,number,picture,unite) values('" + name + "','" + price + "','" + number +"','" + unite + "')", con);

                }

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void update(string name, double price, float number, byte[] picture,string unite, int id)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("update stock set name='" + name + "', price='" + price + "', number='" + number + "',picture= @picture where id='"+id+"'",con);

                cmd.Parameters.AddWithValue("@picture", picture);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
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

        public void delete(string str1)
        {
            try
            {
                con.Open();
                string del = "delete from stock where name='" + str1 + "'";
                MySqlCommand cmd = new MySqlCommand(del, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
        }

        public bool CheckItem(string str1)
        {
            bool result;

            con.Open();
            string check = "select * from stock where name='" + str1 + "'";
            MySqlCommand cmd = new MySqlCommand(check, con);
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
        public bool update(string id, string number)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("update stock set number='" + number + "' where id='" + id + "'", con);
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