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
    public partial class PembayaranSPP : Form
    {
        public PembayaranSPP()
        {
            InitializeComponent();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PembayaranSPP_Load(object sender, EventArgs e)
        {
            txtNoTransaksi.Text = NoTransaksi;
            cbPetugas.DropDownStyle = ComboBoxStyle.DropDownList;
            tampilData();
            tdkaktif();
            tampilCombo();
        }

        private void tampilData()
        {
            string query = "select * from vwPembayaran";
            Manajer.ManajerPembayaran mp = new Manajer.ManajerPembayaran();
            mp.TampilData(query, "vwPembayaran", dgPembayaran);
        }

        private void tampilCombo()
        {
            string query = "select username from tbl_user";
            Fungsi.Set_Combobox(query, "username", cbPetugas);
        }

        private void tdkaktif()
        {
            txtNis.Enabled = false;
            txtNoTransaksi.Enabled = false;
            txtJumlah.Enabled = false;
            txtKeteranganTransaksi.Enabled = false;
            cbPetugas.Enabled = false;
            btnSimpan.Enabled = false;
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
            btnBatal.Enabled = false;
            btnCari.Enabled = false;
        }

        private void bersih()
        {
            txtNis.Clear();
            cbPetugas.SelectedIndex = -1;
            txtJumlah.Clear();
            txtKeteranganTransaksi.Clear();
            txtNoTransaksi.Clear();
            txtNis.Focus();
        }

        private string NoTransaksi
        {
            get
            {
                SqlConnection conn = Koneksi.Conn;
                conn.Open();
                string nomer = "1";
                SqlCommand cmd = new SqlCommand("select max(no_transaksi) from tbl_pembayaran", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader[0].ToString() != "")
                    nomer = (int.Parse(reader[0].ToString()) + 1).ToString("");
                reader.Close();
                return nomer;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            bersih();
            txtNis.Enabled = true;
            txtJumlah.Enabled = true;
            txtKeteranganTransaksi.Enabled = true;
            cbPetugas.Enabled = true;
            txtNis.Focus();
            txtNoTransaksi.Text = NoTransaksi;
            btnSimpan.Enabled = true;
            btnEdit.Enabled = true;
            btnHapus.Enabled = true;
            btnBatal.Enabled = true;
            btnCari.Enabled = true;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Entitas.pembayaran P = new Entitas.pembayaran(int.Parse(txtNoTransaksi.Text), txtNis.Text, dtTanggalTransaksi.Value, txtJumlah.Text, txtKeteranganTransaksi.Text, cbPetugas.Text);
            Manajer.ManajerPembayaran MP = new Manajer.ManajerPembayaran();
            int x = MP.Tambah(P);
            if (txtNis.Text == "")
            {
                MessageBox.Show("NIS Tidak Boleh Kosong!");
            }
            else if (txtJumlah.Text == "")
            {
                MessageBox.Show("Jumlah Biaya Tidak Boleh Kosong!");
            }
            else if (txtKeteranganTransaksi.Text == "")
            {
                MessageBox.Show("Keterangan Transaksi Tidak Boleh Kosong!");
            }
            else if (cbPetugas.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Petugas!");
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
                MessageBox.Show("Pembayaran Gagal Disimpan!");
                bersih();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Entitas.pembayaran P = new Entitas.pembayaran(int.Parse(txtNoTransaksi.Text), txtNis.Text, dtTanggalTransaksi.Value, txtJumlah.Text, txtKeteranganTransaksi.Text, cbPetugas.Text);
            Manajer.ManajerPembayaran MP = new Manajer.ManajerPembayaran();
            int x = (int)MP.Edit(P);
            if (txtNis.Text == "")
            {
                MessageBox.Show("NIS Tidak Boleh Kosong!");
            }
            else if (txtJumlah.Text == "")
            {
                MessageBox.Show("Jumlah Biaya Tidak Boleh Kosong!");
            }
            else if (txtKeteranganTransaksi.Text == "")
            {
                MessageBox.Show("Keterangan Transaksi Tidak Boleh Kosong!");
            }
            else if (cbPetugas.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Petugas!");
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
                MessageBox.Show("Pembayaran Gagal Disimpan!");
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
                query = "delete from tbl_pembayaran where no_transaksi='" + dgPembayaran.CurrentRow.Cells["no_transaksi"].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            tampilData();
            bersih();
        }
        private void dgPembayaran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNoTransaksi.Text = dgPembayaran.CurrentRow.Cells["no_transaksi"].Value.ToString();
            dtTanggalTransaksi.Text = dgPembayaran.CurrentRow.Cells["tgl_transaksi"].Value.ToString();
            txtNis.Text = dgPembayaran.CurrentRow.Cells["nis"].Value.ToString();
            txtJumlah.Text = dgPembayaran.CurrentRow.Cells["jml_biaya"].Value.ToString();
            txtKeteranganTransaksi.Text = dgPembayaran.CurrentRow.Cells["ket_transaksi"].Value.ToString();
            cbPetugas.Text = dgPembayaran.CurrentRow.Cells["petugas"].Value.ToString();
            btnSimpan.Enabled = false;
            btnEdit.Enabled = true;
            btnBatal.Enabled = true;
            btnHapus.Enabled = true;
            txtNis.Enabled = true;
            txtJumlah.Enabled = true;
            txtKeteranganTransaksi.Enabled = true;
            cbPetugas.Enabled = true;
            dtTanggalTransaksi.Enabled = true;
        }
    }
}