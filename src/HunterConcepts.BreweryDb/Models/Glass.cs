using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Models
{
    [Plural("glasses")]
    public class Glass : Model
    {        
        public string Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string Name { get; set; }
    }
}
