using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;

namespace InstitutionStatistic.WebApi.Controllers;

public class RectorController: BaseController<Rector>
{
    public RectorController(IRepository<Rector> repository): base(repository)
    {

    }
}
