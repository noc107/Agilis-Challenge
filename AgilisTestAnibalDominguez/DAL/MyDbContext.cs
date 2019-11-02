using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using AgilisTestAnibalDominguez.Models;

namespace AgilisTestAnibalDominguez.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("myDbContext")
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MyDbContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}