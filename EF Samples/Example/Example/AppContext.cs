using Example.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Example
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Asset> Assets { get; set; }
    }
}