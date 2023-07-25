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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text=="")
            {
                MessageBox.Show("Enter the username!", "Login Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(txtPassword.Text=="")
            {
                MessageBox.Show("Enter the password!", "Login Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string lgn = "select * from tbl_user where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "' ";
                    SqlDataAdapter sdlgn = new SqlDataAdapter(lgn, Koneksi.Conn);
                    DataTable dtLogin = new DataTable();
                    sdlgn.Fill(dtLogin);
                    sdlgn.Dispose();


                    if(dtLogin.Rows.Count == 1)
                    {
                        MessageBox.Show("Login successfull!", "Login Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        DashboardUtama DU = new DashboardUtama();
                        DU.ShowDialog(); // Shows Form2

                    }
                    else
                    {
                        MessageBox.Show("Username or Password is invalid!", "Login Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtUsername.Focus();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin mau tutup Aplikasi ini?", "Application Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }  
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void btnClose_CursorChanged(object sender, EventArgs e)
        {
            
        }
    }
}
