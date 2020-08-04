﻿using System;
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

        public void addStock(string name, double price, float number, byte[] picture,string unite)
        {
            try
            {
                con.Open();
                cmd = new MySqlCommand("Insert into stock (name,price,number,picture,unite) values('" + name + "','" + price + "','" + number + "',@picture,'"+unite+"')", con);
                cmd.Parameters.Add("@picture", MySqlDbType.MediumBlob, (int)picture.Length);
                cmd.Parameters["@picture"].Value = picture;

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
    }
}