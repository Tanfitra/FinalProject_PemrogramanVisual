using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_PV.Entitas
{
    class thnajar
    {
        private string kd_thn, thn;

        public string Kd_thn { get => kd_thn; set => kd_thn = value; }
        public string Thn { get => thn; set => thn = value; }

        public thnajar(string kd_thn, string thn)
        {
            this.Kd_thn = kd_thn;
            this.Thn = thn;
        }
    }
}
