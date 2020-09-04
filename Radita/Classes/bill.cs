using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace Radita.Database
{
    class bill
    {
        MySqlConnection con;
        MySqlCommand cmd;
        
        public bill()
        {
            //con = new MySqlConnection("datasource=192.168.120.11;port=3306;username=root; password=;database=yelemani;");

            Classes.connection c = new Classes.connection();
            con = c.getCon();
        }

        public int getNum()
        {
            int result = 0;
            try
            {
                con.Open();

                MySqlDataAdapter data = new MySqlDataAdapter("select id from Bill", con);
                
                DataTable IDs = new DataTable();
                data.Fill(IDs);

                result = Convert.ToInt32(IDs.Rows[IDs.Rows.Count - 1].ItemArray[0].ToString()) + 1;

                cmd = new MySqlCommand("insert into bill set (id) values('" + result + "')", con);
                
                con.Close();
            }
            catch
            {
                MessageBox.Show("Connection au serveur impossible");
                result = 0;
            }

            return result;
        }

        
        
        public void save(string id, string Path)
        {
            FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read);


            //Byte[] bt = br.ReadBytes((Int32)fs.Length);
            Byte[] bt = new Byte[(Int32)fs.Length];
            fs.Read(bt, 0, (Int32)fs.Length);
            //word.Application app = new word.Application();
            //word.Document doc = app.Documents.Open(Path);
            //app.Visible = false;
            fs.Close();

            try
            {
                con.Open();
                cmd = new MySqlCommand("insert into bill (id,recu) values(@name,@upload)", con);
                cmd.Parameters.Add("@name", MySqlDbType.Int32).Value = Convert.ToInt32(id);
                cmd.Parameters.Add("@upload", MySqlDbType.LongBlob).Value = bt;

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
