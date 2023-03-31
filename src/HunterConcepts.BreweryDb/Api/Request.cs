using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HunterConcepts.BreweryDb.Api
{
    public class Request
    {
        public Request(string key, string endPoint, HttpMethod method)
            : this(key, endPoint, method, string.Empty)
        {            
        }

        public Request(string key, string endPoint, HttpMethod method, string parameters)
        {
            Key = key;
            EndPoint = endPoint;
            Method = method;
            Parameters = parameters;            
            ContentType = "application/json";            
        }

        public string Key { get; private set; }
        public string EndPoint { get; private set; }
        public HttpMethod Method { get; private set; }

        public string Parameters { get; set; }
                
        public string ContentType { get; private set; }
        public byte[] Content { get; private set; }

        public HttpWebRequest HttpWebRequest { get; private set; }

        public Response Send()
        {
            string host = "api.brewerydb.com";
            string url = string.Format("http://{0}/v2/{1}?key={2}&{3}", host, EndPoint, Key, Parameters);

            HttpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            HttpWebRequest.Method = Method.ToString();
            HttpWebRequest.ContentType = ContentType;

            try
            {
                WebResponse response = HttpWebRequest.GetResponse();

                return new Response(HttpWebRequest.GetResponse() as HttpWebResponse);
            }
            catch (WebException webEx)
            {
                return new Response(webEx.Response as HttpWebResponse);
            }            
        }
    }    
}
