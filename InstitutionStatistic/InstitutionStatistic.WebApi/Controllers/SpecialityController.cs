using AutoMapper;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.Domain.Queries;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.ViewObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InstitutionStatistic.WebApi.Controllers;

public class SpecialityController(
    IRepository<Speciality> specialityRepository, 
    IMapper mapper,
    ISpecialityQuery specQuery) : BaseController<Speciality, SpecialityVO>(specialityRepository, mapper)
{
    /// <summary>
    /// Получить топ 5 специальностей
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTopFiveSpecialities")]
    public async Task<ActionResult<List<SpecialityVO>>> GetTopFiveSpecialities()
    {
        var query = await specialityRepository
            .Query()
            .ToListAsync();

        return Ok(mapper.Map<List<SpecialityVO>>(specQuery.GetTopFiveSpecialities(query)));
    }
}
