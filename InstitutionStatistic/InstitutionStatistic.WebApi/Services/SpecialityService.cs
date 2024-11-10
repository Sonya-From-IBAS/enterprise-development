using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace InstitutionStatistic.WebApi.Services;

public class SpecialityService: ISpecialityService
{
    private IRepository<Speciality> _repository;
    public SpecialityService(IRepository<Speciality> repository)
    {
        _repository = repository; ;
    }
    public async Task Test()
    {
        var query = _repository.Query();
        var res = await query.Where(x => x.Name == "SPEC2").Select(p => new {p.Name}).ToListAsync();
        return;
    }
}
