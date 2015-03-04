using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GladiatusBot.Helper {
    public static class WebHandler {
        public static HttpWebRequest CreateHttpRequest(
            string url, 
            string method, 
            string userAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1003.1 Safari/535.19",
            string accept = "text/html, application/xhtml+xml, */*",
            string contentType = "application/x-www-form-urlencoded",
            CookieContainer cookieJar = null)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create( url );
            httpRequest.Method = method;
            httpRequest.Referer = url;
            httpRequest.CookieContainer = cookieJar;
            httpRequest.UserAgent = userAgent;
            httpRequest.Accept = accept;
            httpRequest.ContentType = contentType;
            httpRequest.AutomaticDecompression = DecompressionMethods.GZip;
            return httpRequest;
        }

        public static HttpWebResponse ExecuteRequest( HttpWebRequest httpRequest, Dictionary<string, string> parameters ) {
            string data = "";

            foreach(var kv in parameters) {
                data += kv.Key + "=" + kv.Value + "&";
            }
            data = data.Remove( data.Length - 1 );

            byte[] byteData = Encoding.UTF8.GetBytes( data );

            
            httpRequest.ContentLength = byteData.Length;

            using(Stream stream = httpRequest.GetRequestStream()) {
                stream.Write( byteData, 0, byteData.Length );
                stream.Close();
            }

            httpRequest.AllowAutoRedirect = false;
            return (HttpWebResponse)httpRequest.GetResponse();
        }
    }
}
