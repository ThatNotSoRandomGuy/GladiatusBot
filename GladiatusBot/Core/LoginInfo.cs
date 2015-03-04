using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatusBot.Core {
    public class LoginInfo {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Server { get; private set; }
        public string Country { get; private set; }

        public LoginInfo( string user, string pass, string server, string country ) {
            Username = user;
            Password = pass;
            Server = server;
            Country = country;
        }
    }
}
