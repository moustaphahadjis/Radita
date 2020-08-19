using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Radita.Classes
{
    class scheduler
    {
        MySqlConnection con;
        MySqlCommand cmd;
        public scheduler()
        {
            con = new MySqlConnection("database=radita; port=3306; username=root; password=; datasource= localhost;");
            con.Close();
        }

        public void addNew(string clientName, string clientPhone, string avance, string total, string reste, string date)
        {
            try
            {
                con.Open();

                cmd = new MySqlCommand("insert into scheduler (clientName, clientphone,avance, total, reste, date) values('" + clientName + "','" + clientPhone + "','" + avance + "','" + total + "','" + reste + "','" + date + "')", con);
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void addNew(string clientName, string clientPhone, string avance, string total, string date)
        {
            double reste = Convert.ToDouble(total) - Convert.ToDouble(avance);
            try
            {
                con.Open();

                cmd = new MySqlCommand("insert into scheduler (clientName, clientphone,avance, total, reste, date) values('" + clientName + "','" + clientPhone + "','" + avance + "','" + total + "','" + reste + "','" + date + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void modify(int id,string clientName, string clientPhone, string avance, string total, string reste, string date)
        {
            //Modify details by only using the ID
            try
            {
                con.Open();

                cmd = new MySqlCommand("update scheduler set clientName='" + clientName + "', clientphone='" + clientPhone + "', avance='" + avance + "',reste='" + reste + "',total='" + total + "', date='" + date + "' where id='"+id+"'", con);
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public DataTable getAll()
        {
            try
            {
                con.Open();
                MySqlDataAdapter data = new MySqlDataAdapter("select * from scheduler",con);
                DataTable dt = new DataTable();
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

        public void remove(int id)
        {
            try
            {
                con.Open();

                cmd = new MySqlCommand("delete from scheduler where id ='" + id + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public DataTable dueDate(int dayRange)
        {
            DataTable dt = new DataTable();

            dt= getAll();

            for(int i= dt.Rows.Count; i>0; i++)
            {
                //see if time is less than dayrange and higher than today
                DateTime time = Convert.ToDateTime(dt.Rows[i].ToString());
                if(!(time.CompareTo(DateTime.Now.AddDays(dayRange))<=0 && time.CompareTo(DateTime.Now)>=0))
                {
                    dt.Rows.Remove(dt.Rows[i]);
                }
            }
            return dt;
        }
    }
}
