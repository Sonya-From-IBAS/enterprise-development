using AutoMapper;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.ViewObjects;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionStatistic.WebApi.Controllers;

public class DepartmentController: BaseController<Department, DepartmentVO>
{
    public DepartmentController(IRepository<Department> repository, IMapper mapper) : base(repository, mapper)
    {

    }
}
