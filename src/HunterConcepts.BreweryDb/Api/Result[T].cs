using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Api
{
    public class Result<T> : IResult<T>
        where T : class, new()
    {
        public Result(Response response)
        {
            Response = response;
        }
        public Response Response { get; set; }

        public string Message { get; set; }
        public T Data { get; set; }
        public string Status { get; set; }
    }

    public class ListResult<T> : IResult<T>
        where T : class, new()
    {
        public ListResult(Response response)
        {
            Response = response;
        }
        public Response Response { get; set; }

        public string Message { get; set; }
        public IEnumerable<T> Data { get; set; }
        public string Status { get; set; }
    }
}