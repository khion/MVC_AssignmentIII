using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TPT.Models
{
    public class Service
    {
        public Service()
    {
        this.Students = new HashSet<Customer>();
        this.Instructors = new HashSet<Employee>();
    }
        [Key]
        public string Name { get; set; }
        
        public int Cost { get; set; }
        public virtual ICollection<Customer> Students { get; set; }
        public virtual ICollection<Employee> Instructors { get; set; }
    }
}