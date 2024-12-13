using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;

namespace InstitutionStatistic.WebApi.Controllers;

public class FacultyController: BaseController<Faculty>
{
    public FacultyController(IRepository<Faculty> repository) : base(repository)
    {

    }
}
