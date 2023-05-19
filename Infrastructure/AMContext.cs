using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure
{
    public class AMContext: DbContext
    {

        public DbSet<Client> Clients { get; set; }
        public DbSet<Prestation> Prestations { get; set; }
        public DbSet<Prestataire> Prestataires { get; set; }
        public DbSet<RDV> RDVs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=BeautyWassimBenRomdhaneDB;MultipleActiveResultSets=true;Integrated Security=true") ;
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RDVConfiguration());
            //modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            //modelBuilder.ApplyConfiguration(new TicketConfiguration());

            ////TPT
            //modelBuilder.Entity<Staff>().ToTable("Staff");
            //modelBuilder.Entity<Traveller>().ToTable("Travellers");

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
           configurationBuilder
                .Properties<string>()
                .HaveMaxLength(150);

        //configurationBuilder
        //    .Properties<decimal>()
        //        .HavePrecision(8,3);

            //configurationBuilder
            //  .Properties<DateTime>()
            //      .HaveColumnType("date");
        }



    }
}
