using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Core.Models.Classes;
using Core.Models.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Data
{
    public class DataContext: IdentityDbContext<ApplicationUser>
    {
        public DataContext() : base("League")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<AdministrativeBody> AdministrativeBodies { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Leg> Legs { get; set; }
        //public DbSet<Result> Results { get; set; }
        //public DbSet<Statistic> Statistics { get; set; }
    }
}
