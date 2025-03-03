
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using UnitedGeoCompany.Middlewares;
using UnitedGeoCompany.Repository.Implementations;
using UnitedGeoCompany.Repository.Interfaces;
using UnitedGeoCompany.Services.Implementations;
using UnitedGeoCompany.Services.Interfaces;
using UnitedGeoCompanyDataBase;

namespace UnitedGeoCompany;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("UnitedGeoDatabase");
        builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));

        builder.Services.AddScoped<ISecretaryService, SecretaryService>();
        builder.Services.AddScoped<IBrigadesService, BrigadesService>();


        builder.Services.AddScoped<IObjectiveRepository, ObjectiveRepository>();
        builder.Services.AddScoped<IBrigadeRepository, BrigadeRepository>();
        builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();

        #region Mapster
        var iRegisters = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly
            .GetTypes()
            .Where(type => typeof(IRegister).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()) && type.GetTypeInfo().IsClass && !type.GetTypeInfo().IsAbstract));
        foreach (var type in iRegisters)
        {
            _ = builder.Services.AddSingleton(typeof(IRegister), type);
        }

        builder.Services.AddSingleton<IMapper>(servicesProvider =>
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            var iRegisters = servicesProvider.GetServices<IRegister>();
            typeAdapterConfig.Apply(iRegisters);
            return new Mapper(typeAdapterConfig);
        });

        #endregion Mapster

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "UnitedGeoCompanyAPI");
                options.RoutePrefix = string.Empty; 
            });
        }

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseAuthorization();
        app.MapControllers();

       app.Run();
    }
}
