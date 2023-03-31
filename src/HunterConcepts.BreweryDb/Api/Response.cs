using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HunterConcepts.BreweryDb.Api
{
    public class Response
    {
        public string Raw { get; protected set; }
        public HttpWebResponse HttpWebResponse { get; protected set; }
        public HttpStatusCode StatusCode { get { return HttpWebResponse.StatusCode; } }

        public Response(HttpWebResponse httpWebResponse)
        {
            HttpWebResponse = httpWebResponse;

            Stream responseStream = HttpWebResponse.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Raw = reader.ReadToEnd();
        }

        public Response(WebException exception)
            : this(exception.Response as HttpWebResponse)
        {
        }

        public PagedResult<T> ToPagedResult<T>()
            where T : class, new()
        {
            var result = JsonConvert.DeserializeObject<PagedResult<T>>(Raw);
            result.Response = this;
            return result;
        }

        public ListResult<T> ToListResult<T>()
            where T : class, new()
        {
            var result = JsonConvert.DeserializeObject<ListResult<T>>(Raw);
            result.Response = this;
            return result;
        }

        public Result<T> ToResult<T>()
            where T : class, new()
        {
            var result = JsonConvert.DeserializeObject<Result<T>>(Raw);
            result.Response = this;
            return result;
        }
    }
}
