using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Api.Data.Entities;

namespace Vehicles.Api.Data
{
    public class DataContext : DbContext
    {
        //constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //nombre de la tabla a crear (clase )
        public DbSet<Brand> Brands { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<VehiclesType> VehiclesType { get; set; }

        
        //se sobre escribe el metodo OnModelCreating 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>().HasIndex(x => x.Description).IsUnique(); //se especifica que el campo va a ser unico
            modelBuilder.Entity<DocumentType>().HasIndex(x => x.Description).IsUnique(); //se especifica que el campo va a ser unico
            modelBuilder.Entity<Procedure>().HasIndex(x => x.Description).IsUnique(); //se especifica que el campo va a ser unico
            modelBuilder.Entity<VehiclesType>().HasIndex(x => x.Description).IsUnique(); //se especifica que el campo va a ser unico
        }
        
    }
}
