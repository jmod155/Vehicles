using System.Linq;
using System.Threading.Tasks;
using Vehicles.Api.Data.Entities;
using Vehicles.Api.Helpers;
using Vehicles.Common.Enums;

namespace Vehicles.Api.Data
{
    //esta clae sirve para verificar si exiete la bd
    //si no existe la crea y la pobla de datos
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;

        }
        //metodo para verificar si la bd existe o tiene migraciones 
        //pendientes si no existe la bd la crea y si no hace nada
        public async Task SeedAsync()
        {
            //se vericaa que existe la bd
            await _context.Database.EnsureCreatedAsync();
            //se verifica que existan los tipos de vehiculos
            await CheckVehiclesTypeAsync();
            await CheckBrandsAsync();
            await CheckDocumentTypesAsync();
            await CheckProceduresAsync();
            await CheckRolesAsync();
            await CheckUserAsync("10", "JM", "ortiz", "JM@yopmail.com", "311 322 4620", "calle 123", UserType.Admin);
            await CheckUserAsync("1010", "jose", "ortiz", "jose@yopmail.com", "311 322 4620", "calle 123", UserType.Admin);
            await CheckUserAsync("2020", "luis", "ortiz", "luis@yopmail.com", "311 322 4620", "calle 123", UserType.User);
            await CheckUserAsync("3030", "miguel", "ortiz", "miguel@yopmail.com", "311 322 4620", "calle 123", UserType.User);
        }

        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);//se busca el usuario
            if (user == null) //si no existe se crea
            {
                user = new User
                {
                    Address = address,
                    Document = document,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(x => x.Description == "Cédula"),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };
                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());//se crear el rol
            await _userHelper.CheckRoleAsync(UserType.User.ToString());//se crear el rol
        }

        private async Task CheckProceduresAsync()
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

        private async Task CheckDocumentTypesAsync()
        {
            //si no existen VehiclesType
            if (!_context.DocumentTypes.Any())
            {   //si no existen creo los registros
                _context.DocumentTypes.Add(new DocumentType { Description = "Cédula" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Nit" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckBrandsAsync()
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

        private async Task CheckVehiclesTypeAsync()
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
