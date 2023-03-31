using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterConcepts.BreweryDb.Models
{
    [Plural("locations")]
    public class Location : DependentModel
    {        
        public string Id { get; set; }

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string Locality { get; set; }

        public string Region { get; set; }

        public string Phone { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string IsPrimary { get; set; }

        public string InPlanning { get; set; }

        public string IsClosed { get; set; }

        public string OpenToPublic { get; set; }

        public string LocationType { get; set; }

        public string CountryIsoCode { get; set; }

        public Country Country { get; set; }

        public Brewery Brewery { get; set; }
    }
}
