using GladiatusBot.Models;
using GladiatusBot.RegularExpressions;
using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GladiatusBot.Core {
    public class GladiatusClient {

        private RestClient  _RestClient      = null;
        private LoginInfo   _LoginInfo       = null;
        private string      _BaseUrl         = null;
        private string      _CookieGladiatus = null;
        private string      _CookieDevice    = null;
        private string      _SecureHash      = null;

        public GladiatusClient(LoginInfo info) {
            _LoginInfo = info;
            _BaseUrl = String.Format( "http://{0}.{1}.gladiatus.gameforge.com/game", info.Server, info.Country );
            _RestClient = new RestClient( _BaseUrl ) {
                FollowRedirects = false,
                CookieContainer = new CookieContainer()
            };
        }

        private RestRequest CreateGladiatusRequest( Method method, bool useCookies = true, bool useHash = true ) {

            var req = new RestRequest( "index.php", method );
            req.AddHeader( "Accept", "text/html, application/xhtml+xml" );
            if(useHash)
                req.AddParameter( "sh", _SecureHash );
            if(useCookies){
                req.AddCookie( "device", _CookieDevice );
                req.AddCookie( "Gladiatus", _CookieGladiatus );
            }
            return req;

        }

        public bool Login() {
            RestRequest request = CreateGladiatusRequest( Method.POST, false, false );
            request.AddHeader( "Content-Type", "application/x-www-form-urlencoded" );
            request.AddParameter( "mod", "start" );
            request.AddParameter( "submod", "login" );
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

        public PlayerOverview GetOverview() {
            PlayerOverview overview = new PlayerOverview();
            RestRequest request = CreateGladiatusRequest( Method.GET, false, true );
            request.AddParameter( "mod", "overview" );

            var response = _RestClient.Execute( request );

            if(response.StatusCode == HttpStatusCode.OK) {
                try {
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml( response.Content );

                    var honourMatch     = Regex.Match( doc.GetElementbyId( "sstat_highscore" ).InnerHtml, Patterns.HONOUR_PATTERN );
                    var hpMatch         = Regex.Match( doc.GetElementbyId( "header_values_hp" ).InnerHtml, Patterns.HITPOINTS_PATTERN );
                    var expMatch        = Regex.Match( doc.GetElementbyId( "header_values_xp" ).InnerHtml, Patterns.EXPERIENCE_PATTERN );

                    overview.Gold = int.Parse( doc.GetElementbyId( "sstat_gold_val" ).InnerHtml, System.Globalization.NumberStyles.AllowThousands );
                    overview.Rubies = int.Parse( doc.GetElementbyId( "sstat_ruby_val" ).InnerHtml, System.Globalization.NumberStyles.AllowThousands );
                    overview.Ranking = int.Parse( doc.GetElementbyId( "highscorePlace" ).InnerHtml, System.Globalization.NumberStyles.AllowThousands );
                    overview.Level = int.Parse( doc.GetElementbyId( "header_values_level" ).InnerHtml, System.Globalization.NumberStyles.AllowThousands );

                    overview.Honour = int.Parse( honourMatch.Groups["Honour"].Value, System.Globalization.NumberStyles.AllowThousands );
                    overview.CurrentHP = int.Parse( hpMatch.Groups["CurrentHP"].Value, System.Globalization.NumberStyles.AllowThousands );
                    overview.MaxHP = int.Parse( hpMatch.Groups["MaxHP"].Value, System.Globalization.NumberStyles.AllowThousands );
                    overview.CurrentXP = int.Parse( expMatch.Groups["CurrentExp"].Value, System.Globalization.NumberStyles.AllowThousands );
                    overview.RequiredXP = int.Parse( expMatch.Groups["MaxExp"].Value, System.Globalization.NumberStyles.AllowThousands );

                    return overview;
                } catch(Exception ex) {
                    System.Windows.Forms.MessageBox.Show( ex.Message, "Exception", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
                    return null;
                }
            } else {
                return null;
            }
        }


    }
}
