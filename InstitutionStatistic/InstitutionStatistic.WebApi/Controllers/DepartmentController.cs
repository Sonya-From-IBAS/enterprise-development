using AutoMapper;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.ViewObjects;

namespace InstitutionStatistic.WebApi.Controllers;

public class DepartmentController(IRepository<Department> repository, IMapper mapper) : BaseController<Department, DepartmentVO>(repository, mapper)
{
}
