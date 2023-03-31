using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Models
{
    [Plural("images")]
    public class Image : Model
    {
        public string Icon { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }
}
