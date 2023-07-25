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
    class ManajerSiswa
    {
        static int temp;
        static string query;

        //metod tambah data 
        public int Tambah(Entitas.siswa s)
        {
            temp = 0;
            query = "INSERT INTO tbl_siswa VALUES( " +
                "'" + s.Nis + "'," +
                "'" + s.Tgl_daftar + "'," +
                "'" + s.Nama_siswa + "'," +
                "'" + s.Jeniskelamin + "'," +
                "'" + s.Tempat_lahir + "'," +
                "'" + s.Tgl_lahir.ToString("yyyy-MM-dd") + "'," +
                "'" + s.Agama + "'," +
                "'" + s.Alamat + "'," +
                "'" + s.Kd_thn + "'," +
                "'" + s.Nama_ayah + "'," +
                "'" + s.Pend_ayah + "'," +
                "'" + s.Pekerjaan_ayah + "'," +
                "'" + s.Nama_ibu + "'," +
                "'" + s.Pend_ibu + "'," +
                "'" + s.Pekerjaan_ibu + "'," +
                "'" + s.Hasil_ortu + "')";

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
        public object Edit(Entitas.siswa es)
        {
            temp = 0;
            query = " UPDATE tbl_siswa SET " +

                "nis='" + es.Nis + "'," +
                "tgl_daftar='" + es.Tgl_daftar + "'," +
                "nama_siswa='" + es.Nama_siswa + "'," +
                "jeniskelamin='" + es.Jeniskelamin + "'," +
                "tempat_lahir='" + es.Tempat_lahir + "'," +
                "tgl_lahir='" + es.Tgl_lahir.ToString("yyyy-MM-dd") + "'," +
                "agama='" + es.Agama + "'," +
                "alamat='" + es.Alamat + "','" +
                "kd_thn='" + es.Kd_thn + "','" +
                "nama_ayah='" + es.Nama_ayah + "'," +
                "pend_ayah='" + es.Pend_ayah + "'," +
                "pekerjaan_ayah='" + es.Pekerjaan_ayah + "'," +
                "nama_ibu='" + es.Nama_ibu + "'," +
                "pend_ibu='" + es.Pend_ibu + "'," +
                "pekerjaan_ibu='" + es.Pend_ibu + "'," +
                "hasil_ortu='" + es.Hasil_ortu + "'" +
                "WHERE nama_siswa = '" + es.Nama_siswa + "'";
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
            query = "DELETE FROM tbl_siswa WHERE nis = '" + ha + "'";
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
                dg.Columns[0].HeaderText = "NIS";
                dg.Columns[1].HeaderText = "Nama siswa";
                dg.Columns[2].HeaderText = "Jenis kelamin";
                dg.Columns[3].HeaderText = "Tempat lahir";
                dg.Columns[4].HeaderText = "Tanggal lahir";
                dg.Columns[5].HeaderText = "Agama";
                dg.Columns[6].HeaderText = "Alamat";
                dg.Columns[7].HeaderText = "Tahun Ajaran";
                dg.Columns[8].HeaderText = "Nama ayah";                
                dg.Columns[9].HeaderText = "Pekerjaan ayah";
                dg.Columns[10].HeaderText = "Pendidikan ayah";
                dg.Columns[11].HeaderText = "Nama ibu";
                dg.Columns[12].HeaderText = "Pekerjaan ibu";
                dg.Columns[13].HeaderText = "Pendidikan ibu";
                dg.Columns[14].HeaderText = "Hasil ortu";

                dg.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dg.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
