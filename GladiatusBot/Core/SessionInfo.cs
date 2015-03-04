using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiatusBot.Core {
    public class SessionInfo {
        public bool IsLogged;
        public string Cookie;
        public string SecureHash;

        public SessionInfo(bool logged, string cookie, string hash) {
            IsLogged = logged;
            Cookie = cookie;
            SecureHash = hash;
        }
    }
}
