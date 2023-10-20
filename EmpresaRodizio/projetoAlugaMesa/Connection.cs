using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetoAlugaMesa
{
    class Connection
    {
        private static string userPass = "Server=localhost;Port=3306;Database=dbaluguelmesa;Uid=admindb;Pwd=123456";
        private static MySqlConnection con = null;

        public static MySqlConnection getConnection()
        {
            con = new MySqlConnection(userPass);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                con = null;
            }
            return con;
        }

        public static void closeConnection()
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
}
