using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalProject_PV.Manajer
{
    class ManajerUser
    {
        static int temp;
        static string query;

        //method tambah data 
        public int Tambah(Entitas.user eu)
        {
            temp = 0;
            query = "INSERT INTO tbl_user VALUES ( " +
                "'" + eu.Username + "'," +
                "'" + eu.Password + "'," +
                "'" + eu.Hak_akses + "')";

            try
            {
                temp = Fungsi.EQuery(query);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return temp;
        }

        //method update  data 
        public object Edit(Entitas.user u)
        {
            temp = 0;
            query = " UPDATE tbl_user SET " +

                "username='" + u.Username + "'," +
                "password='" + u.Password + "'," +
                "hak_akses='" + u.Hak_akses + "'" +
                "WHERE username = '" + u.Username + "'";
            try
            {
                temp = Fungsi.EQuery(query);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return temp;
        }

        //method hapus data
        public int hapus(string ha)
        {
            temp = 0;
            query = "DELETE FROM tbl_user WHERE username= '" + ha + "'";
            try
            {
                temp = Fungsi.EQuery(query);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.ToString());
            }
            return temp;
        }

        //METHODE MENAMPILKAN DATA
        public void TampilData(String query, string tabel, DataGridView dg)
        {
            try
            {
                dg.DataSource = Fungsi.DataGrid(query, tabel);
                dg.DataMember = tabel;
                dg.Columns[0].HeaderText = "Username";
                dg.Columns[1].HeaderText = "Hak Akses";

                dg.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.Message);
            }
            finally { }
        }
    }
}
