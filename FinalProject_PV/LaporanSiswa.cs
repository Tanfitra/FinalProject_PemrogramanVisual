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
    public partial class LaporanSiswa : Form
    {
        public LaporanSiswa()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void LaporanSiswa_Load(object sender, EventArgs e)
        {
            
        }
        public static void Laporan(string query, string tabel)
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

                LaporanSiswa lp = new LaporanSiswa();
                //lp.crystalReportViewer1.DisplayGroupTree = true;
                lp.crystalReportViewer1.ReportSource = myreport;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin mau tutup halaman ini?", "Application Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DashboardUtama DU = new DashboardUtama();
                this.Close();
                DU.Show();
            }
        }
    }
}
