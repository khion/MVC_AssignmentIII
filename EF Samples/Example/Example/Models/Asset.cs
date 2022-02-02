using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class Asset
    {
        public int ID { get; set; }
        public string name { get; set; }
        public virtual Renter renter { get; set; }
    }
}