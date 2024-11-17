using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Users.Domain.Entities;

namespace Users.Infrastructure.Database;

public class DatabaseInitializer(
    ApplicationDbContext context, 
    ILogger<DatabaseInitializer> logger)
{
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger<DatabaseInitializer> _logger = logger;

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
            await InitializeCitiesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while migrating or ensuring the database is created.");
            throw;
        }
    }

    public async Task InitializeCitiesAsync()
    {
        try
        {
            if (!_context.Cities.Any())
            {
                var defaultCountry = new Country { Name = "Colombia" };

                _context.Countries.Add(defaultCountry);

                var cities = new List<City>
                {
                    new City { Name = "Bogotá", Country = defaultCountry },
                    new City { Name = "Medellín", Country = defaultCountry },
                    new City { Name = "Cali", Country = defaultCountry },
                    new City { Name = "Barranquilla", Country = defaultCountry },
                    new City { Name = "Cartagena", Country = defaultCountry },
                    new City { Name = "Bucaramanga", Country = defaultCountry },
                    new City { Name = "Pereira", Country = defaultCountry },
                    new City { Name = "Manizales", Country = defaultCountry },
                    new City { Name = "Santa Marta", Country = defaultCountry },
                    new City { Name = "Cúcuta", Country = defaultCountry },
                    new City { Name = "Ibagué", Country = defaultCountry },
                    new City { Name = "Neiva", Country = defaultCountry },
                    new City { Name = "Villavicencio", Country = defaultCountry },
                    new City { Name = "Pasto", Country = defaultCountry },
                    new City { Name = "Armenia", Country = defaultCountry },
                    new City { Name = "Montería", Country = defaultCountry },
                    new City { Name = "Sincelejo", Country = defaultCountry },
                    new City { Name = "Popayán", Country = defaultCountry },
                    new City { Name = "Tunja", Country = defaultCountry },
                    new City { Name = "Riohacha", Country = defaultCountry },
                    new City { Name = "Valledupar", Country = defaultCountry },
                    new City { Name = "Quibdó", Country = defaultCountry },
                    new City { Name = "Florencia", Country = defaultCountry },
                    new City { Name = "San Andrés", Country = defaultCountry },
                    new City { Name = "Leticia", Country = defaultCountry },
                    new City { Name = "Mocoa", Country = defaultCountry },
                    new City { Name = "Yopal", Country = defaultCountry },
                    new City { Name = "Arauca", Country = defaultCountry },
                    new City { Name = "Mitú", Country = defaultCountry },
                    new City { Name = "Puerto Carreño", Country = defaultCountry },
                    new City { Name = "Buenaventura", Country = defaultCountry },
                    new City { Name = "Tumaco", Country = defaultCountry },
                    new City { Name = "Turbo", Country = defaultCountry },
                    new City { Name = "Apartadó", Country = defaultCountry },
                    new City { Name = "Girardot", Country = defaultCountry },
                    new City { Name = "Zipaquirá", Country = defaultCountry },
                    new City { Name = "Soacha", Country = defaultCountry },
                    new City { Name = "Facatativá", Country = defaultCountry },
                    new City { Name = "Chía", Country = defaultCountry },
                    new City { Name = "Fusagasugá", Country = defaultCountry },
                    new City { Name = "Sogamoso", Country = defaultCountry },
                    new City { Name = "Duitama", Country = defaultCountry },
                    new City { Name = "Chiquinquirá", Country = defaultCountry },
                    new City { Name = "Ipiales", Country = defaultCountry },
                    new City { Name = "Tuluá", Country = defaultCountry },
                    new City { Name = "Palmira", Country = defaultCountry },
                    new City { Name = "Buga", Country = defaultCountry },
                    new City { Name = "Jamundí", Country = defaultCountry },
                    new City { Name = "Yumbo", Country = defaultCountry },
                    new City { Name = "Cartago", Country = defaultCountry },
                    new City { Name = "Rionegro", Country = defaultCountry },
                    new City { Name = "Envigado", Country = defaultCountry },
                    new City { Name = "Itagüí", Country = defaultCountry },
                    new City { Name = "Sabaneta", Country = defaultCountry },
                    new City { Name = "Bello", Country = defaultCountry },
                    new City { Name = "Copacabana", Country = defaultCountry },
                    new City { Name = "La Estrella", Country = defaultCountry },
                    new City { Name = "Caldas", Country = defaultCountry },
                    new City { Name = "Barbosa", Country = defaultCountry },
                    new City { Name = "Girardota", Country = defaultCountry },
                    new City { Name = "Caucasia", Country = defaultCountry },
                    new City { Name = "Apartadó", Country = defaultCountry },
                    new City { Name = "Turbo", Country = defaultCountry },
                    new City { Name = "Carepa", Country = defaultCountry },
                    new City { Name = "Chigorodó", Country = defaultCountry },
                    new City { Name = "Necoclí", Country = defaultCountry },
                    new City { Name = "Arboletes", Country = defaultCountry },
                    new City { Name = "San Pedro de Urabá", Country = defaultCountry },
                    new City { Name = "San Juan de Urabá", Country = defaultCountry },
                    new City { Name = "Mutatá", Country = defaultCountry },
                    new City { Name = "Murindó", Country = defaultCountry },
                    new City { Name = "Vigía del Fuerte", Country = defaultCountry },
                    new City { Name = "Carmen de Atrato", Country = defaultCountry },
                    new City { Name = "Bojayá", Country = defaultCountry },
                    new City { Name = "Medio Atrato", Country = defaultCountry },
                    new City { Name = "Medio Baudó", Country = defaultCountry },
                    new City { Name = "Medio San Juan", Country = defaultCountry },
                    new City { Name = "Nóvita", Country = defaultCountry },
                    new City { Name = "Río Iró", Country = defaultCountry },
                    new City { Name = "Río Quito", Country = defaultCountry },
                    new City { Name = "Riosucio", Country = defaultCountry },
                    new City { Name = "San José del Palmar", Country = defaultCountry },
                    new City { Name = "Sipí", Country = defaultCountry },
                    new City { Name = "Tadó", Country = defaultCountry },
                    new City { Name = "Unguía", Country = defaultCountry },
                    new City { Name = "Unión Panamericana", Country = defaultCountry }
                };

                _context.Cities.AddRange(cities);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing cities.");
            throw;
        }
    }
}
