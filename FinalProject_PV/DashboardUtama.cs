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
    public partial class DashboardUtama : Form
    {
        public DashboardUtama()
        {
            InitializeComponent();

            tglStrip.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            timeStrip.Text = DateTime.Now.ToString("H:mm:ss");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin mau tutup Aplikasi ini?", "Application Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            this.Hide();
            PendaftaranSiswa PS = new PendaftaranSiswa();
            PS.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin mau keluar?", "Application Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login lg = new Login();
                this.Close();
                lg.Show();
            }
        }

        private void btnSPP_Click(object sender, EventArgs e)
        {
            this.Hide();
            PembayaranSPP SPP = new PembayaranSPP();
            SPP.ShowDialog();
        }

        private void btnGuru_Click(object sender, EventArgs e)
        {

        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            HalamanAdmin DA = new HalamanAdmin();
            DA.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThnAjaran_Click(object sender, EventArgs e)
        {
            this.Hide();
            TahunAjar TA = new TahunAjar();
            TA.ShowDialog();
        }

        private void btnLaporanSiswa_Click(object sender, EventArgs e)
        {
            this.Hide();
            string query = "select * from tbl_siswa";
            LS(query, "tbl_siswa");
        }

        public static void LS(string query, string tabel)
        {
            SqlConnection Conn = Koneksi.Conn;

            try
            {
                Conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, Conn);
                DataSet ds = new DataSet();
                sda.Fill(ds, tabel);

                CRSiswa myreport = new CRSiswa();
                myreport.SetDataSource(ds);

                LaporanSiswa ls = new LaporanSiswa();
                //lp.crystalReportViewer1.DisplayGroupTree = true;
                ls.crystalReportViewer1.ReportSource = myreport;
                ls.Show();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void btnLaporanPembayaran_Click(object sender, EventArgs e)
        {
            this.Hide();
            string query = "select * from tbl_pembayaran";
            LP(query, "tbl_pembayaran");
        }

        public static void LP(string query, string tabel)
        {
            SqlConnection Conn = Koneksi.Conn;

            try
            {
                Conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, Conn);
                DataSet ds = new DataSet();
                sda.Fill(ds, tabel);

                CRPembayaran myreport1 = new CRPembayaran();
                myreport1.SetDataSource(ds);

                LaporanPembayaran lp = new LaporanPembayaran();
                //lp.crystalReportViewer1.DisplayGroupTree = true;
                lp.crystalReportViewer1.ReportSource = myreport1;
                lp.Show();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Conn.Close();
            }
        }
    }
}