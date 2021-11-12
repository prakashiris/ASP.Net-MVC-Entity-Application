using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntitytoDatabse.Models
{
    public class StoreContext : DbContext
        {
            public StoreContext(): base("CustomDbName")
                {

                }
            public DbSet<Product> Product { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Role> Roles { get; set; }

            public DbSet<User> User { get; set; }
           
            public DbSet<Supplier> Suppliers { get; set; }

        }
    
}