using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Models
{
    [Plural("beers")]
    public class Beer : PrimaryModel
    {
        public Beer()
        {
            Labels = new Image();
            Breweries = new List<Brewery>();
            SocialAccounts = new List<SocialAccount>();
        }
                
        public new string Id { get; set; }

        public new DateTime CreateDate { get; set; }
        public new DateTime? UpdateDate { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string FoodPairings { get; set; }

        public string OriginalGravity { get; set; }

        public string Abv { get; set; }

        public string Ibu { get; set; }
        
        public string Type { get; set; }

        public string IsOrganic { get; set; }

        public string Status { get; set; }

        public string StatusDisplay { get; set; }

        public Style Style { get; set; }

        public Glass Glass { get; set; }

        public virtual IList<Brewery> Breweries { get; set; }

        public virtual IList<SocialAccount> SocialAccounts { get; set; }

        public Image Labels { get; set; }

        public virtual Availability Available { get; set; }

        public int Year { get; set; }
    }

    
}
