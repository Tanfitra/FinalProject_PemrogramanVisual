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
    class ManajerTahunAjar
    {
        static int temp;
        static string query;

        //metod tambah data 
        public int Tambah(Entitas.thnajar ta)
        {
            temp = 0;
            query = "INSERT INTO tbl_thnajaran VALUES ( " +
                "'" + ta.Kd_thn + "'," +
                "'" + ta.Thn + "')";

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

        //metod  hapus  data 
        public int hapus(string ha)
        {
            temp = 0;
            query = "DELETE FROM tbl_thnajaran WHERE kd_thn= '" + ha + "'";
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
                dg.Columns[0].HeaderText = "Kode Tahun";
                dg.Columns[1].HeaderText = "Tahun Ajaran";

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
