using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProject_PV
{
    class Koneksi
    {
        private static string conn;  

        static Koneksi()
        {
            string connStr = @"Data Source=LAPTOP-NCGNEM4P\SQLEXPRESS2008;Initial Catalog=dbAdministrasiSekolah;Integrated Security=True";
            conn = connStr;

        }
         public static SqlConnection Conn
        {
            get
            {
                return new SqlConnection(conn);
            }
        }


    }

    
}
