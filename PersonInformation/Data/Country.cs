using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonInformation.Data
{
    public class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
        public ICollection<Info> Info { get; set; }

        
    }


}
