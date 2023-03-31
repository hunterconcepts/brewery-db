using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Api
{
    public interface IResult<T>
        where T : class, new()
    {
        string Status { get; set; }
        Response Response { get; }
    }
}
