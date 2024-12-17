using AutoMapper;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.ViewObjects;

namespace InstitutionStatistic.WebApi.Controllers;

public class RectorController: BaseController<Rector, RectorVO>
{
    public RectorController(IRepository<Rector> repository, IMapper mapper) : base(repository, mapper)
    {

    }
}
