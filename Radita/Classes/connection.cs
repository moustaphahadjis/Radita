using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Radita.Classes
{
    class connection
    {
        MySqlConnection con;
        public connection()
        {
            con = new MySqlConnection("database= radita; port=3306; datasource= localhost; username=root; password=;");
            con.Close();
        }

        public MySqlConnection getCon()
        {
            return con;
        }

    }
}
