using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SistemaRecargaTarjeta
{
    public class Conexion
    {
        private static SqlConnection conn = null;

        private Conexion()
        {
            
        }

        public static SqlConnection getConnection()
        {
            try
            {
                //url = "datasource=127.0.0.1;port=3306;username=root;password=;database=tiendacamarena";
                if (conn == null)
                {
                    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConectarSQL"].ConnectionString);
                }  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return conn;
        }

        public static void close()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }



        //public static Conexion ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConectarMYSQL").ConnectionString;
        //public static Conection;



    }
}