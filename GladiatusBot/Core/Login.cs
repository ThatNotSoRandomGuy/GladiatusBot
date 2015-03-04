using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GladiatusBot.Core {
    public class Login {
        private RestClient  _RestClient;
        private string      _Username;
        private string      _Password;

        public Login( RestClient rest, string user, string pass ) {
            _Username = user;
            _Password = pass;
            _RestClient = rest;
        }

        /*public LoginInfo DoLogin() {
            RestRequest request = new RestRequest( "index.php?mod=start&submod=login", Method.POST );
            request.AddHeader( "Accept", "text/html, application/xhtml+xml" );
            request.AddHeader( "Content-Type", "application/x-www-form-urlencoded" );
            request.AddParameter( "name", _Username );
            request.AddParameter( "pass", _Password );

            var response = _RestClient.Execute( request );
            
            string redirectUrl = (string)response.Headers.Where(h => h.Type == ParameterType.HttpHeader && h.Name == "Location").SingleOrDefault().Value;
            string cookieHeader = (string)response.Headers.Where( h => h.Type == ParameterType.HttpHeader && h.Name == "Set-Cookie" ).SingleOrDefault().Value;

            var cookieMatch = Regex.Match( cookieHeader, "(Gladiatus=[^;,]*?;) expires", RegexOptions.CultureInvariant );

            var hashMatch = Regex.Match( redirectUrl, "index\\.php\\?mod=overview&login=1&sh=([^&]*)" );

            if(!cookieMatch.Success || !hashMatch.Success) //Could not login.
                return new LoginInfo(false, "","");

            return new LoginInfo( true, cookieMatch.Groups[1].Value, hashMatch.Groups[1].Value );
        }*/
    }
}
