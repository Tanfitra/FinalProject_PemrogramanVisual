using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_PV.Entitas
{
    class user
    {
        private string username, password, hak_akses;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Hak_akses { get => hak_akses; set => hak_akses = value; }

        public user(string username, string password, string hak_akses)
        {
            this.Username = username;
            this.Password = password;
            this.Hak_akses = hak_akses;
        }
    }
}
