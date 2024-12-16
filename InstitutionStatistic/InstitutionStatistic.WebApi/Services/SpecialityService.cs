using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.ViewObjects;
using Microsoft.EntityFrameworkCore;

namespace InstitutionStatistic.WebApi.Services;

public class SpecialityService: ISpecialityService
{
    private IRepository<Speciality> _repository;
    public SpecialityService(IRepository<Speciality> repository)
    {
        _repository = repository; ;
    }

    public async Task<List<SpecialityVO>> GetTopFive()
    {
        var query = _repository.Query();
        return await query.OrderByDescending(x => x.Groups.Count).Take(5).Select(x => new SpecialityVO {
        Id = x.Id,
        Version = x.Version,
        Name = x.Name,
        Code = x.Code}).ToListAsync();
    }
}
