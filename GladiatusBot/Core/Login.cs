using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GladiatusBot.Core {
    public class Login {

        private RestClient  _RestClient;
        private string      _Username;
        private string      _Password;

        private string      _SecureHash;
        private bool        _Successful;

        public string SecureHash { get { return _SecureHash; } }
        public bool Successful { get { return _Successful; } }

        public Login( RestClient client, string user, string pass ) {
            _RestClient = client;
            _Username = user;
            _Password = pass;
        }

        public bool DoLogin() {
            var request = new RestRequest( "/game/index.php?mod=start&submod=login", Method.POST );
            request.AddParameter( "name", _Username );
            request.AddParameter( "pass", _Password );

            var response = _RestClient.Execute( request );
            var match = System.Text.RegularExpressions.Regex.Match( response.Content, "href=\"index\\.php\\?mod=news&submod=serverEvents&sh=([^&]*?)\"" );

            _Successful = match.Success;

            if(!_Successful) //Could not login.
                return false;

            _SecureHash = match.Groups[0].Value;

            return _Successful;
        }
    }
}
