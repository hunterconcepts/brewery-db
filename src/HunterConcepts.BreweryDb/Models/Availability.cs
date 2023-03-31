using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Models
{
    [Plural("availabilities")]
    public partial class Availability : Model
    {        
        public string Id { get; set; }
                
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
