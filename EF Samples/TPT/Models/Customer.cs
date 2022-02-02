using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TPT.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Customers")]
    public class Customer : Person
    {
        public Customer()
        {
            this.Services = new HashSet<Service>();
        }

        //public int GPA { get; set; }
        public virtual ICollection<Service> Services { get; set; }

    }
}