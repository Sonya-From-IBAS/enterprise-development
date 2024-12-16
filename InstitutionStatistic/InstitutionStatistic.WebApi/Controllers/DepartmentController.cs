using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionStatistic.WebApi.Controllers;

public class DepartmentController: BaseController<Department>
{
    public DepartmentController(IRepository<Department> repository) : base(repository)
    {

    }
}
