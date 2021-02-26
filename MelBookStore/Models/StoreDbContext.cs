using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MelBookStore.Models
{
    // This is what the database is going to house information about 
    // Your specific DbContext inherits a DbContext from Microsoft.EntityFrameworkCore (: means inherit) 
    public class StoreDbContext : DbContext
    {
        // This is a constructor that is called when an instance of the object is built for the first time. 
        // This inherits all the base options from the base (the class itself)
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
    }
}
