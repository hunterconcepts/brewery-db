using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HunterConcepts.BreweryDb.Models
{
    [Plural("breweries")]
    public class Brewery : PrimaryModel
    {
        public Brewery()
        {
            Images = new Image();
            Beers = new List<Beer>();
            SocialAccounts = new List<SocialAccount>();
            Locations = new List<Location>();
            AlternateNames = new List<AlternateName>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Website { get; set; }

        public string Established { get; set; }

        public string MailingListUrl { get; set; }

        public string IsOrganic { get; set; }
        
        public Image Images { get; set; }

        public virtual IList<Beer> Beers { get; set; }

        public virtual IList<SocialAccount> SocialAccounts { get; set; }

        public virtual IList<Location> Locations { get; set; }

        public virtual IList<AlternateName> AlternateNames { get; set; }
    }

    public class AlternateName : DependentModel
    {
        public string Id { get; set; }

        public string AltName { get; set; }
    }
}
