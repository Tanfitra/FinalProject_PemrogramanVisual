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
    public partial class PendaftaranSiswa : Form
    {
        public PendaftaranSiswa()
        {
            InitializeComponent();
        }

        private void PendaftaranSiswa_Load(object sender, EventArgs e)
        {
            tampilData();
            tdkaktif();
            cbJenisKelamin.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAgama.DropDownStyle = ComboBoxStyle.DropDownList;
            cbThnAjar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPekerjaanAyah.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPekerjaanIbu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHasilOrtu.DropDownStyle = ComboBoxStyle.DropDownList;
            tampilCombo();
            txtNIS.Text = NIS;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void tampilData()
        {
            string query = "select * from vwSiswa";
            Manajer.ManajerSiswa ms = new Manajer.ManajerSiswa();
            ms.TampilData(query, "vwSiswa", dgSiswa);
        }

        private void tampilCombo()
        {
            string query = "select thn from tbl_thnajaran";
            Fungsi.Set_Combobox(query, "thn", cbThnAjar);
        }

        private string NIS
        {
            get
            {
                SqlConnection conn = Koneksi.Conn;
                conn.Open();
                string nomer = "1";
                SqlCommand cmd = new SqlCommand("select max(nis) from tbl_siswa", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader[0].ToString() != "")
                    nomer = "0" + (int.Parse(reader[0].ToString()) + 1).ToString("0");
                reader.Close();
                return nomer;
            }
        }
        private void tdkaktif()
        {
            txtNIS.Enabled = false;
            txtNamaSiswa.Enabled = false;
            cbJenisKelamin.Enabled = false;
            txtTempatLahir.Enabled = false;
            cbAgama.Enabled = false;
            txtAlamat.Enabled = false;
            cbThnAjar.Enabled = false;
            txtNamaAyah.Enabled = false;
            txtPendAyah.Enabled = false;
            cbPekerjaanAyah.Enabled = false;
            txtNamaIbu.Enabled = false;
            txtPendIbu.Enabled = false;
            cbPekerjaanIbu.Enabled = false;
            cbHasilOrtu.Enabled = false;
            btnSimpan.Enabled = false;
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
            btnBatal.Enabled = false;
            btnCari.Enabled = false;
        }

        private void bersih()
        {
            txtNIS.Clear();
            txtNamaSiswa.Clear();
            cbJenisKelamin.SelectedIndex = -1;
            txtTempatLahir.Clear();
            cbAgama.SelectedIndex = -1;
            txtAlamat.Clear();
            cbThnAjar.SelectedIndex = -1;
            txtNamaAyah.Clear();
            txtPendAyah.Clear();
            cbPekerjaanAyah.SelectedIndex = -1;
            txtNamaIbu.Clear();
            txtPendIbu.Clear();
            cbPekerjaanIbu.SelectedIndex = -1;
            cbHasilOrtu.SelectedIndex = -1;
            txtNIS.Focus();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            bersih();
            txtNIS.Enabled = false;
            txtNamaSiswa.Enabled = true;
            cbJenisKelamin.Enabled = true;
            txtTempatLahir.Enabled = true;
            cbAgama.Enabled = true;
            cbThnAjar.Enabled = true;
            txtAlamat.Enabled = true;
            txtNamaAyah.Enabled = true;
            txtPendAyah.Enabled = true;
            cbPekerjaanAyah.Enabled = true;
            txtNamaIbu.Enabled = true;
            txtPendIbu.Enabled = true;
            cbPekerjaanIbu.Enabled = true;
            cbHasilOrtu.Enabled = true;
            btnSimpan.Enabled = true;
            btnEdit.Enabled = true;
            btnHapus.Enabled = true;
            btnBatal.Enabled = true;
            btnCari.Enabled = true;
            txtNamaSiswa.Focus();
            txtNIS.Text = NIS;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Entitas.siswa s = new Entitas.siswa(txtNIS.Text, dtTanggalDaftar.Value, txtNamaSiswa.Text, cbJenisKelamin.Text, txtTempatLahir.Text, dtTanggalLahir.Value, cbAgama.Text, txtAlamat.Text,
                cbThnAjar.Text, txtNamaAyah.Text, txtPendAyah.Text, cbPekerjaanAyah.Text, txtNamaIbu.Text, txtPendIbu.Text, cbPekerjaanIbu.Text, cbHasilOrtu.Text);
            Manajer.ManajerSiswa ms = new Manajer.ManajerSiswa();
            int x = ms.Tambah(s);
            if (txtNIS.Text == " ")
            {
                MessageBox.Show("NIS Tidak Boleh Kosong");
            }
            else if (dtTanggalDaftar.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("Pilih Tanggal Daftar Sekarang!");
            }
            else if (txtNamaSiswa.Text == "")
            {
                MessageBox.Show("Nama Siswa Tidak Boleh Kosong");
            }
            else if (txtTempatLahir.Text == " ")
            {
                MessageBox.Show("Tempat Lahir Tidak Boleh Kosong");
            }
            else if (txtAlamat.Text == " ")
            {
                MessageBox.Show("Alamat Tidak Boleh Kosong");
            }
            else if (cbThnAjar.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Tahun Ajaran!");
            }
            else if (txtNamaAyah.Text == " ")
            {
                MessageBox.Show("Nama Ayah Tidak Boleh Kosong");
            }
            else if (txtPendAyah.Text == " ")
            {
                MessageBox.Show("Pilih Pendidikan Ayah!");
            }
            else if (cbPekerjaanAyah.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Pekerjaan Ayah!");
            }
            else if (txtNamaIbu.Text == " ")
            {
                MessageBox.Show("Nama Ibu Tidak Boleh Kosong");
            }
            else if (txtPendIbu.Text == " ")
            {
                MessageBox.Show("Pilih Pendidikan Ibu!");
            }
            else if (cbPekerjaanIbu.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Pekerjaan Ibu!");
            }
            else if (cbHasilOrtu.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Penghasilan Orang Tua!");
            }
            else if (x == 1)
            {
                MessageBox.Show("Data Berhasil Disimpan");
                tampilData();
                bersih();
                tdkaktif();
            }
            else
            {
                MessageBox.Show("NIS Tersebut Sudah Ada di Database!");
                bersih();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Entitas.siswa s = new Entitas.siswa(txtNIS.Text, dtTanggalDaftar.Value, txtNamaSiswa.Text, cbJenisKelamin.Text, txtTempatLahir.Text, dtTanggalLahir.Value, cbAgama.Text, txtAlamat.Text,
                cbThnAjar.Text, txtNamaAyah.Text, txtPendAyah.Text, cbPekerjaanAyah.Text, txtNamaIbu.Text, txtPendIbu.Text, cbPekerjaanIbu.Text, cbHasilOrtu.Text);
            Manajer.ManajerSiswa ms = new Manajer.ManajerSiswa();
            int x = (int)ms.Edit(s);
            if (txtNIS.Text == " ")
            {
                MessageBox.Show("NIS Tidak Boleh Kosong");
            }
            else if (dtTanggalDaftar.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("Pilih Tanggal Daftar Sekarang!");
            }
            else if (txtNamaSiswa.Text == "")
            {
                MessageBox.Show("Nama Siswa Tidak Boleh Kosong");
            }
            else if (txtTempatLahir.Text == " ")
            {
                MessageBox.Show("Tempat Lahir Tidak Boleh Kosong");
            }
            else if (txtAlamat.Text == " ")
            {
                MessageBox.Show("Alamat Tidak Boleh Kosong");
            }
            else if (txtNamaAyah.Text == " ")
            {
                MessageBox.Show("Nama Ayah Tidak Boleh Kosong");
            }
            else if (txtNamaIbu.Text == " ")
            {
                MessageBox.Show("Nama Ibu Tidak Boleh Kosong");
            }
            else if (x == 1)
            {
                MessageBox.Show("Data Berhasil Disimpan");
                tampilData();
                bersih();
                tdkaktif();
            }
            else
            {
                MessageBox.Show("Data Gagal Diedit!");
                bersih();
            }

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin mau hapus data ini?", "Application Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlConnection con = Koneksi.Conn;
                con.Open();
                string query;
                query = "delete from tbl_siswa where nis='" + dgSiswa.CurrentRow.Cells["nis"].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            tampilData();
            bersih();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void dgSiswa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNIS.Text = dgSiswa.CurrentRow.Cells["nis"].Value.ToString();
            txtNamaSiswa.Text = dgSiswa.CurrentRow.Cells["nama_siswa"].Value.ToString();
            cbJenisKelamin.Text = dgSiswa.CurrentRow.Cells["jeniskelamin"].Value.ToString();
            txtTempatLahir.Text = dgSiswa.CurrentRow.Cells["tempat_lahir"].Value.ToString();
            dtTanggalLahir.Text = dgSiswa.CurrentRow.Cells["tgl"].Value.ToString();
            cbAgama.Text = dgSiswa.CurrentRow.Cells["agama"].Value.ToString();
            txtAlamat.Text = dgSiswa.CurrentRow.Cells["alamat"].Value.ToString();
            cbThnAjar.Text = dgSiswa.CurrentRow.Cells["thn"].Value.ToString();
            txtNamaAyah.Text = dgSiswa.CurrentRow.Cells["nama_ayah"].Value.ToString();
            cbPekerjaanAyah.Text = dgSiswa.CurrentRow.Cells["pekerjaan_ayah"].Value.ToString();
            txtPendAyah.Text = dgSiswa.CurrentRow.Cells["pend_ayah"].Value.ToString();
            txtNamaIbu.Text = dgSiswa.CurrentRow.Cells["nama_ibu"].Value.ToString();
            cbPekerjaanIbu.Text = dgSiswa.CurrentRow.Cells["pekerjaan_ibu"].Value.ToString();
            txtPendIbu.Text = dgSiswa.CurrentRow.Cells["pend_ibu"].Value.ToString();
            cbHasilOrtu.Text = dgSiswa.CurrentRow.Cells["hasil_ortu"].Value.ToString();
            btnSimpan.Enabled = false;
            btnEdit.Enabled = true;
            btnBatal.Enabled = true;
            btnHapus.Enabled = true;
            txtNamaSiswa.Enabled = true;
            cbJenisKelamin.Enabled = true;
            txtTempatLahir.Enabled = true;
            txtAlamat.Enabled = true;
            txtNamaAyah.Enabled = true;
            txtPendAyah.Enabled = true;
            cbPekerjaanAyah.Enabled = true;
            txtNamaIbu.Enabled = true;
            txtPendIbu.Enabled = true;
            cbPekerjaanIbu.Enabled = true;
            cbHasilOrtu.Enabled = true;
            dtTanggalDaftar.Enabled = true;
            dtTanggalLahir.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}