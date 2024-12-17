using AutoMapper;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.Services;
using InstitutionStatistic.WebApi.ViewObjects;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionStatistic.WebApi.Controllers;

public class SpecialityController: BaseController<Speciality, SpecialityVO>
{
    private ISpecialityService _specialityService;

    public SpecialityController(
        ISpecialityService specialityService, 
        IRepository<Speciality> specialityRepository
        , IMapper mapper) : base(specialityRepository, mapper)
    {
        _specialityService = specialityService;
    }

    /// <summary>
    /// Получить топ 5 специальностей
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTopFiveSpecialities")]
    public async Task<ActionResult<List<SpecialityVO>>> GetTopFiveSpecialities()
    {
        return Ok(await _specialityService.GetTopFive());
    }
}
