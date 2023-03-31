using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Models
{
    public class SocialAccount : Model
    {
        public string Id { get; set; }

        public string Handle { get; set; }

        public string Link { get; set; }

        public DateTime CreateDate { get; set; }

        public SocialMedia SocialMedia { get; set; }

    }
}
