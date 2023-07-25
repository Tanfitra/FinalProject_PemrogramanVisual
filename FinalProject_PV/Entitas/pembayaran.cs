using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_PV.Entitas
{
    class pembayaran
    {
        private string jml_biaya, ket_transaksi, petugas, nis;
        private int no_transaksi;
        private DateTime tgl_transaksi;

        public string Jml_biaya { get => jml_biaya; set => jml_biaya = value; }
        public string Ket_transaksi { get => ket_transaksi; set => ket_transaksi = value; }
        public string Petugas { get => petugas; set => petugas = value; }
        public int No_transaksi { get => no_transaksi; set => no_transaksi = value; }
        public string Nis { get => nis; set => nis = value; }
        public DateTime Tgl_transaksi { get => tgl_transaksi; set => tgl_transaksi = value; }

        public pembayaran(int no_transaksi, string nis, DateTime tgl_transaksi, string jml_biaya, string ket_transaksi, string petugas)
        {
            this.No_transaksi = no_transaksi;
            this.Nis = nis;
            this.Tgl_transaksi = tgl_transaksi;
            this.Jml_biaya = jml_biaya;
            this.Ket_transaksi = ket_transaksi;
            this.Petugas = petugas;
        }
    }
}
