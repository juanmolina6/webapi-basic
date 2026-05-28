using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Literals;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations;

public static class DbConfigurations
{
    public static IServiceCollection SetDatabaseConfiguration(this IServiceCollection services)
    {
        //var connectionString = Environment.GetEnvironmentVariable(MyVaccineLiterals.CONNECTION_STRING);
        var connectionString = @"Server=LAPTOP-343I6EK6;Database=MyVaccineAppDb;Integrated Security=True;TrustServerCertificate=True;";
        services.AddDbContext<MyVaccineAppDbContext>(options =>
                    options.UseSqlServer(
                                connectionString
                                )
                    );
        return services;
    }
}