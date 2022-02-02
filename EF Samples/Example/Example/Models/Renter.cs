using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class Renter
    {
        public Renter()
        {
            Assets = new HashSet<Asset>();
        }
        public int ID { get; set; }
        public string name { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }

    }
}