using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Radita.Classes
{
    class historiquePartenaire
    {
        MySqlConnection con;
        MySqlCommand cmd;
        public historiquePartenaire()
        {
                Classes.connection c = new Classes.connection();
                con = c.getCon();

            }

            public DataTable getAll()
            {
                DataTable dt = new DataTable();
                try
                {
                    con.Open();
                    MySqlDataAdapter data = new MySqlDataAdapter("select * from historiquePartenaire", con);
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
            public void addNew(string nom, string telephone, string action, string montant)
            {
                try
                {
                    con.Open();

                    cmd = new MySqlCommand("Insert into historiquePartenaire (nom, telephone, action,montant, date) values('" + nom + "','" + telephone + "','" + action + "', '" + montant + "','" + DateTime.Now.ToString() + "')", con);
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