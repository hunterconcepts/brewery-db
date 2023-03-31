using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Models
{
    [Plural("styles")]
    public class Style : Model
    {        
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string SrmMin { get; set; }
        public string SrmMax { get; set; }
        public string IbuMin { get; set; }
        public string IbuMax { get; set; }
        public string Description { get; set; }
        public string FgMin { get; set; }
        public string FgMax { get; set; }
        public string AbvMin { get; set; }
        public string AbvMax { get; set; }
        public Category Category { get; set; }
    }
}
