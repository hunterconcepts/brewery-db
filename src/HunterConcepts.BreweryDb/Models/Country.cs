using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Models
{
    [Plural("countries")]
    public partial class Country : Model
    {
        public string IsoCode { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string IsoThree { get; set; }
                
        public int NumberCode { get; set; }
    }
}
