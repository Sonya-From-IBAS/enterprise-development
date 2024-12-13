using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionStatistic.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialityController: BaseController<Speciality>
{
    private ISpecialityService _specialityService;

    public SpecialityController(ISpecialityService specialityService, IRepository<Speciality> specialityRepository): base(specialityRepository)
    {
        _specialityService = specialityService;
    }

    [HttpGet]
    public async Task<ActionResult> Test()
    {
        await _specialityService.Test();
        return Ok();
    }

}
