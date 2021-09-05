using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.Api.Data.Entities;

namespace Vehicles.Api.Data
{
    //esta clae sirve para verificar si exiete la bd
    //si no existe la crea y la pobla de datos
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;
            
        }
        //metodo para verificar si la bd existe o tiene migraciones 
        //pendientes si no existe la bd la crea y si no hace nada
        public async Task SeedAsync()
        {
            //se vericaa que existe la bd
            await _context.Database.EnsureCreatedAsync();
            //se verifica que existan los tipos de vehiculos
            await checkVehiclesTypeAsync();
            await checkBrandsAsync();
            await checkDocumentTypesAsync();
            await checkProceduresAsync();
        }

        private async Task checkProceduresAsync()
        {
            //si no existen VehiclesType
            if (!_context.Procedures.Any())
            {   //si no existen creo los registros
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Alineación" });
                _context.Procedures.Add(new Procedure { Price = 20000, Description = "Lubricación de suspención delantera" });
                _context.Procedures.Add(new Procedure { Price = 30000, Description = "Lubricación de suspención trasera" });
                _context.Procedures.Add(new Procedure { Price = 40000, Description = "Frenos delanteros" });
                _context.Procedures.Add(new Procedure { Price = 50000, Description = "Frenos traseros" });
                _context.Procedures.Add(new Procedure { Price = 60000, Description = "Líquido frenos delanteros" });
                _context.Procedures.Add(new Procedure { Price = 70000, Description = "Líquido frenos traseros" });
                _context.Procedures.Add(new Procedure { Price = 80000, Description = "Calibración de válvulas" });
                _context.Procedures.Add(new Procedure { Price = 90000, Description = "Alineación carburador" });
                _context.Procedures.Add(new Procedure { Price = 100000, Description = "Aceite motor" });
                
                await _context.SaveChangesAsync();
            }
        }

        private async Task checkDocumentTypesAsync()
        {
            //si no existen VehiclesType
            if (!_context.DocumentTypes.Any())
            {   //si no existen creo los registros
                _context.DocumentTypes.Add(new DocumentType { Description = "Cedula" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Nit" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task checkBrandsAsync()
        {
            //si no existen VehiclesType
            if (!_context.Brands.Any())
            {   //si no existen creo los registros
                _context.Brands.Add(new Brand { Description = "Kymco" });
                _context.Brands.Add(new Brand { Description = "Honda" });
                _context.Brands.Add(new Brand { Description = "Auteco" });
                _context.Brands.Add(new Brand { Description = "Bmw" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task checkVehiclesTypeAsync()
        {    //si no existen VehiclesType
            if (!_context.VehiclesType.Any())
            {   //si no existen creo los registros
                _context.VehiclesType.Add(new VehiclesType { Description = "Carro" });
                _context.VehiclesType.Add(new VehiclesType { Description = "Moto" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
