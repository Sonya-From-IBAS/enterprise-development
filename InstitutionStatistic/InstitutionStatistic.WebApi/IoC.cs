using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.Services;

namespace InstitutionStatistic.WebApi;

public class IoC
{
    public static void Init(IServiceCollection Services)
    {
        Services.AddScoped<IInstitutionService, InstitutionService>();
        Services.AddScoped<ISpecialityService, SpecialityService>();
        Services.AddScoped<IRepository<Institution>, Repository<Institution>>();
        Services.AddScoped<IRepository<Speciality>, Repository<Speciality>>();
        Services.AddScoped<IRepository<Faculty>, Repository<Faculty>>();
        Services.AddScoped<IRepository<Department>, Repository<Department>>();
    }
}
