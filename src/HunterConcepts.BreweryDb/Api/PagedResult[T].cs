using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Api
{
    public class PagedResult<T> : IResult<T>
        where T : class, new()
    {
        public PagedResult() { }

        public PagedResult(IQueryable<T> query, int currentPage, int pageSize)
        {
            if (currentPage > 0 && pageSize > 0)
            {
                var totalResults = query.Count();                
                var numberOfPages = totalResults / pageSize;
                var skip = (currentPage - 1) * pageSize;

                TotalResults = totalResults;
                CurrentPage = currentPage;
                NumberOfPages = numberOfPages;
                Data = query.Skip(skip).Take(pageSize).ToList();
            }
        }

        public PagedResult(Response response)
        {
            Response = response;
        }

        public Response Response { get; set; }

        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public int TotalResults { get; set; }
        public IEnumerable<T> Data { get; set; }
        public string Status { get; set; }
    }
}
