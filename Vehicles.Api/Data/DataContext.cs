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
        public DbSet<VehiclesType> VehiclesType { get; set; }
        //se sobre escribe el metodo OnModelCreating 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehiclesType>().HasIndex(x => x.Description).IsUnique(); //se especifica que el campo va a ser unico
        }
        
    }
}
