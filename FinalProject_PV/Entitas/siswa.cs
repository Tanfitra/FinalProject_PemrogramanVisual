using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_PV.Entitas
{
    class siswa
    {
        private string nis, nama_siswa, jeniskelamin, tempat_lahir, agama, alamat, kd_thn, nama_ayah, pend_ayah, pekerjaan_ayah, nama_ibu, pend_ibu, pekerjaan_ibu, hasil_ortu;
        private DateTime tgl_daftar, tgl_lahir;

        public string Nama_siswa { get => nama_siswa; set => nama_siswa = value; }
        public string Jeniskelamin { get => jeniskelamin; set => jeniskelamin = value; }
        public string Tempat_lahir { get => tempat_lahir; set => tempat_lahir = value; }
        public string Agama { get => agama; set => agama = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Nama_ayah { get => nama_ayah; set => nama_ayah = value; }
        public string Pend_ayah { get => pend_ayah; set => pend_ayah = value; }
        public string Pekerjaan_ayah { get => pekerjaan_ayah; set => pekerjaan_ayah = value; }
        public string Nama_ibu { get => nama_ibu; set => nama_ibu = value; }
        public string Pend_ibu { get => pend_ibu; set => pend_ibu = value; }
        public string Pekerjaan_ibu { get => pekerjaan_ibu; set => pekerjaan_ibu = value; }
        public string Hasil_ortu { get => hasil_ortu; set => hasil_ortu = value; }
        public string Nis { get => nis; set => nis = value; }
        public DateTime Tgl_daftar { get => tgl_daftar; set => tgl_daftar = value; }
        public DateTime Tgl_lahir { get => tgl_lahir; set => tgl_lahir = value; }
        public string Kd_thn { get => kd_thn; set => kd_thn = value; }

        public siswa (string nis, DateTime tgl_daftar, string nama_siswa, string jeniskelamin, string tempat_lahir, DateTime tgl_lahir, string agama, string alamat, string kd_thn, string nama_ayah, string pend_ayah, string pekerjaan_ayah, string nama_ibu,
            string pend_ibu, string pekerjaan_ibu, string hasil_ortu)
        {
            this.Nis = nis;
            this.Tgl_daftar = tgl_daftar;
            this.Nama_siswa = nama_siswa;
            this.Jeniskelamin = jeniskelamin;
            this.Tempat_lahir = tempat_lahir;
            this.Tgl_lahir = tgl_lahir;
            this.Agama = agama;
            this.Alamat = alamat;
            this.Kd_thn = kd_thn;
            this.Nama_ayah = nama_ayah;
            this.Pend_ayah = pend_ayah;
            this.Pekerjaan_ayah = pekerjaan_ayah;
            this.Nama_ibu = nama_ibu;
            this.Pend_ibu = pend_ibu;
            this.Pekerjaan_ibu = pekerjaan_ibu;
            this.Hasil_ortu = hasil_ortu;
            
            
            
        }
    }
}
