using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace FinalProject_PV
{
    class Fungsi : Koneksi
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static SqlDataAdapter sda;
        static SqlDataReader sdr;
        static DataSet ds;

        //untuk akses query
        public static int EQuery(string query)
        {
            conn = Koneksi.Conn;
            cmd = new SqlCommand();
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = query;

                int i = cmd.ExecuteNonQuery();
                return i;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        // isi data GridView
        public static DataSet DataGrid(string query, string tabel)
        {
            conn = Koneksi.Conn;
            sda = new SqlDataAdapter(query, conn);
            ds = new DataSet();

            try
            {
                conn.Open();
                sda.Fill(ds, tabel);
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Set_Combobox(string Query, string row, ComboBox box)
        {
            try
            {
                conn = Koneksi.Conn;
                conn.Open();
                SqlCommand comm = new SqlCommand(Query, conn);

                sdr = comm.ExecuteReader();
                box.Items.Clear();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        box.Items.Add(sdr[row]);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (sdr != null)
                    sdr.Close();
                conn.Close();
            }

        }

        //Cari
        public static void Cari(string query, string tabel, DataGridView dg)
        {
            conn = Koneksi.Conn;

            try
            {
                conn.Open();
                sda = new SqlDataAdapter(query, conn);
                ds = new DataSet();
                sda.Fill(ds, tabel);
                dg.DataSource = ds;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }

}
