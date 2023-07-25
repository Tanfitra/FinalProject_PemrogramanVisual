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
    class ManajerPembayaran
    {
        static int temp;
        static string query;

        //metod tambah data 
        public int Tambah(Entitas.pembayaran pb)
        {
            temp = 0;
            query = "INSERT INTO tbl_pembayaran VALUES ( " +
                "'" + pb.No_transaksi + "'," +
                "'" + pb.Nis + "'," +
                "'" + pb.Tgl_transaksi + "'," +
                "'" + pb.Jml_biaya + "'," +
                "'" + pb.Ket_transaksi + "'," + 
                "'" + pb.Petugas + "')";

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

        //metod update  data 
        public object Edit(Entitas.pembayaran epb)
        {
            temp = 0;
            query = " UPDATE tbl_pembayaran SET " +
                "no_transaksi='" + epb.No_transaksi + "'," +
                "nis='" + epb.Nis + "'," +
                "tgl_transaksi='" + epb.Tgl_transaksi + "'," +
                "jml_biaya='" + epb.Jml_biaya + "'," +
                "ket_transaksi='" + epb.Ket_transaksi + "'," +
                "petugas='" + epb.Petugas + "'," +
                "WHERE no_transaksi = '" + epb.No_transaksi + "'";
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
        public int Hapus(string ha)
        {
            temp = 0;
            query = "DELETE FROM tbl_pembayaran WHERE no_transaksi= '" + ha + "'";
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
                dg.Columns[0].HeaderText = "No Transaksi";
                dg.Columns[1].HeaderText = "Tanggal Transaksi";
                dg.Columns[2].HeaderText = "NIS";
                dg.Columns[3].HeaderText = "Nama Siswa";
                dg.Columns[4].HeaderText = "Tahun Ajaran";
                dg.Columns[5].HeaderText = "Jumlah Biaya";
                dg.Columns[6].HeaderText = "Keterangan Transaksi";
                dg.Columns[7].HeaderText = "Petugas";

                dg.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
