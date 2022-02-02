using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace TPT.Models
{
    public class Person
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
       
        public string Address { get; set; }
    }
}