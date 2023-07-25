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
    public partial class HalamanAdmin : Form
    {
        public HalamanAdmin()
        {
            InitializeComponent();
        }

        private void HalamanAdmin_Load(object sender, EventArgs e)
        {
            cbHakAkses.DropDownStyle = ComboBoxStyle.DropDownList;
            tdkaktif();
            tampilData();
        }

        private void tampilData()
        {
            string query = "select username, hak_akses from tbl_user";
            Manajer.ManajerUser mu = new Manajer.ManajerUser();
            mu.TampilData(query, "tbl_user", dgUser);
        }

        private void bersih()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cbHakAkses.SelectedIndex = -1;
            txtUsername.Focus();
        }

        private void tdkaktif()
        {
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            cbHakAkses.Enabled = false;
            btnBatal.Enabled = false;
            btnEdit.Enabled = false;
            btnSimpan.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            bersih();
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            cbHakAkses.Enabled = true;
            txtUsername.Focus();
            btnSimpan.Enabled = true;
            btnBatal.Enabled = true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Entitas.user u = new Entitas.user(txtUsername.Text, txtPassword.Text, cbHakAkses.Text);
            Manajer.ManajerUser mu = new Manajer.ManajerUser();
            int x = mu.Tambah(u);
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Username Tidak Boleh Kosong!");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Password Tidak Boleh Kosong!");
            }
            else if (cbHakAkses.Text == "")
            {
                MessageBox.Show("Hak Akses Tidak Boleh Kosong!");
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
                MessageBox.Show("Username Tersebut Sudah Ada Di Database!");
                bersih();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Entitas.user u = new Entitas.user(txtUsername.Text, txtPassword.Text, cbHakAkses.Text);
            Manajer.ManajerUser mu = new Manajer.ManajerUser();
            int x = (int)mu.Edit(u);
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Username Tidak Boleh Kosong!");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Password Tidak Boleh Kosong!");
            }
            else if (cbHakAkses.Text == "")
            {
                MessageBox.Show("Hak Akses Tidak Boleh Kosong!");
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
                MessageBox.Show("Username Tersebut Sudah Ada Di Database!");
                bersih();
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
                query = "delete from tbl_user where username='" + dgUser.CurrentRow.Cells["username"].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            tampilData();
            bersih();
        }

        private void dgUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsername.Text = dgUser.CurrentRow.Cells["username"].Value.ToString();
            cbHakAkses.Text = dgUser.CurrentRow.Cells["hak_akses"].Value.ToString();
            btnSimpan.Enabled = false;
            btnEdit.Enabled = true;
            btnBatal.Enabled = true;
            btnHapus.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            cbHakAkses.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin mau tutup halaman ini?", "Application Information",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DashboardUtama DU = new DashboardUtama();
                this.Close();
                DU.Show();
            }
        }
    }
}
