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
using GladiatusBot.Helper;
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

        public SessionInfo DoLogin() {
            CookieContainer cookies = new CookieContainer();
            _RestClient.FollowRedirects = false;
            _RestClient.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1003.1 Safari/535.19";
            _RestClient.CookieContainer = cookies;

            RestRequest request = new RestRequest( "/game/index.php?mod=start&submod=login", Method.POST );
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
                return new SessionInfo(false, "","");

            return new SessionInfo( true, cookieMatch.Groups[1].Value, hashMatch.Groups[1].Value );
        }
    }
}
