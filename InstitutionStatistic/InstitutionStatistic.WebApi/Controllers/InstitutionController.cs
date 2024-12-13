using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionStatistic.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstitutionController: BaseController<Institution>
{
    public InstitutionController(IRepository<Institution> institutionRepository) : base(institutionRepository)
    {

    }
}
