using InstitutionStatistic.WebApi.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Services;
namespace InstitutionStatistic.WebApi;

public class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<InstitutionDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        });

        services.AddAutoMapper(typeof(AppMappingProfile));
        services.AddScoped<IInstitutionService, InstitutionService>();
        services.AddScoped<ISpecialityService, SpecialityService>();
        services.AddScoped<IRepository<Institution>, Repository<Institution>>();
        services.AddScoped<IRepository<Speciality>, Repository<Speciality>>();
        services.AddScoped<IRepository<Faculty>, Repository<Faculty>>();
        services.AddScoped<IRepository<Department>, Repository<Department>>();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
