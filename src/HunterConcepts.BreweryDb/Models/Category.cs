using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Models
{
    [Plural("categories")]
    public class Category : Model
    {        
        public string Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string Name { get; set; }
    }
}
