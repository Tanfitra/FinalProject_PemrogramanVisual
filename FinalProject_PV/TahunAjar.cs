using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalProject_PV
{
    public partial class TahunAjar : Form
    {
        public TahunAjar()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TahunAjar_Load(object sender, EventArgs e)
        {
            txtKodeThnAjaran.Text = NoUrut;
            tampilData();
            txtKodeThnAjaran.Enabled = false;
            txtThnAjaran.Enabled = false;
            btnSimpan.Enabled = false;
            btnBatal.Enabled = false;
        }

        private string NoUrut
        {
            get
            {
                SqlConnection conn = Koneksi.Conn;
                conn.Open();
                string nomer = "TA001";
                SqlCommand cmd = new SqlCommand("select max(right(kd_thn,3)) from tbl_thnajaran", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader[0].ToString() != "")
                    nomer = "TA" + (int.Parse(reader[0].ToString()) + 1).ToString("000");
                reader.Close();
                return nomer;

            }
        }

        private void tampilData()
        {
            string query = "select * from tbl_thnajaran order by kd_thn asc";
            Manajer.ManajerTahunAjar mta = new Manajer.ManajerTahunAjar();
            mta.TampilData(query, "tbl_thnajaran", dgTahun);
        }

        private void bersih()
        {
            txtKodeThnAjaran.Clear();
            txtThnAjaran.Clear();
            txtKodeThnAjaran.Focus();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            bersih();
            txtThnAjaran.Enabled = true;
            btnSimpan.Enabled = true;
            btnBatal.Enabled = true;
            txtKodeThnAjaran.Text = NoUrut;
            txtThnAjaran.Focus();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Entitas.thnajar ta = new Entitas.thnajar(txtKodeThnAjaran.Text, txtThnAjaran.Text);
            Manajer.ManajerTahunAjar mta = new Manajer.ManajerTahunAjar();
            int x = mta.Tambah(ta);
            if (txtThnAjaran.Text == "")
            {
                MessageBox.Show("Kode Tahun Ajaran Tidak Boleh Kosong!");
            }
            else if (txtThnAjaran.Text.Length != 9)
            {
                MessageBox.Show("Pengisian Tahun Ajaran Harus 9 Karakter!");
            }
            else if (x == 1)
            {
                MessageBox.Show("Data Berhasil Disimpan");
                bersih();
                tampilData();
                btnSimpan.Enabled = false;
            }
            else
            {
                MessageBox.Show("Format Tahun Ajaran Salah!, Contoh : 2023/2024");
                bersih();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin mau tutup halaman ini?", "Application Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DashboardUtama DU = new DashboardUtama();
                this.Close();
                DU.Show();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin mau hapus data ini?", "Application Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlConnection con = Koneksi.Conn;
                con.Open();
                string query;
                query = "delete from tbl_thnajaran where kd_thn='" + dgTahun.CurrentRow.Cells["kd_thn"].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            tampilData();
            bersih();
        }
    }
}