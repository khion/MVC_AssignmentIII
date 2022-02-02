using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
namespace TPT.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Service> Services { get; set; }
        public System.Data.Entity.DbSet<TPT.Models.Customer> Students { get; set; }
        public System.Data.Entity.DbSet<TPT.Models.Employee> Instructors { get; set;}

    }
}