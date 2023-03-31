using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Models
{
    public class BreweryDbWebHook
    {
        public BrewerDbWebHookAttribute Attribute { get; set; }

        public string AttributeId { get; set; }

        public DateTime Timestamp { get; set; }

        public BrewerDbWebHookAction Action { get; set; }

        public string SubAttributeId { get; set; }

        public string SubAction { get; set; }
    }

    public enum BrewerDbWebHookAction
    {
        Insert = 1,
        Delete = 2,
        Edit = 3
    }

    public enum BrewerDbWebHookAttribute
    {
        Beer = 1,
        Brewery = 2,
        Location = 3,
        Guild = 4,
        Event = 5
    }
}
