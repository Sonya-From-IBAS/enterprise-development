using InstitutionStatistic.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionStatistic.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialityController: ControllerBase
{
    private ISpecialityService _specialityService;

    public SpecialityController(ISpecialityService specialityService)
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
