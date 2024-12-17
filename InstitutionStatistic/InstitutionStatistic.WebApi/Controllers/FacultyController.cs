using AutoMapper;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.ViewObjects;

namespace InstitutionStatistic.WebApi.Controllers;

public class FacultyController: BaseController<Faculty, FacultyVO>
{
    public FacultyController(IRepository<Faculty> repository, IMapper mapper) : base(repository, mapper)
    {

    }
}
