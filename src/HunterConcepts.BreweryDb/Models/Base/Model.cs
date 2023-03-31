using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Models
{
    public abstract class PrimaryModel : DependentModel
    {        
        public string Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }        
    }

    public abstract class DependentModel : Model
    {
    }

    public abstract class Model
    {        
    }    
}
