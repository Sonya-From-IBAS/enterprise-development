using AutoMapper;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.ViewObjects;

namespace InstitutionStatistic.WebApi.Controllers;

public class RectorController(IRepository<Rector> repository, IMapper mapper) : BaseController<Rector, RectorVO>(repository, mapper)
{

}
