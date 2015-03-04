using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GladiatusBot.Core {
    public class GladiatusClient {

        private string _BaseUrl;
        private RestClient _RestClient;
        private LoginInfo _LoginInfo;

        private string _CookieGladiatus;
        private string _CookieDevice;
        private string _SecureHash;

        public GladiatusClient(LoginInfo info) {
            _LoginInfo = info;
            _BaseUrl = String.Format( "http://{0}.{1}.gladiatus.gameforge.com/game", info.Server, info.Country );
            _RestClient = new RestClient( _BaseUrl ) {
                FollowRedirects = false,
                CookieContainer = new CookieContainer()
            };
        }

        public bool Login() {
            RestRequest request = new RestRequest( "index.php?mod=start&submod=login", Method.POST );
            request.AddHeader( "Accept", "text/html, application/xhtml+xml" );
            request.AddHeader( "Content-Type", "application/x-www-form-urlencoded" );
            request.AddParameter( "name", _LoginInfo.Username );
            request.AddParameter( "pass", _LoginInfo.Password );

            var response = _RestClient.Execute( request );

            if(response.StatusCode == HttpStatusCode.Found) {
                foreach(RestResponseCookie restResponseCookie in response.Cookies) {
                    if(restResponseCookie.Name == "device") {
                        _CookieDevice = restResponseCookie.Value;
                    }
                    if(restResponseCookie.Name == "Gladiatus") {
                        _CookieGladiatus = restResponseCookie.Value;
                    }
                }
                string location = (from header in response.Headers where header.Name == "Location" select header.Value).SingleOrDefault() as string;
                _SecureHash = Regex.Match( location, @"&sh=([^&]*)" ).Groups[1].Value;
            } else {
                return false;
            }

            return true;
        }
    }
}
