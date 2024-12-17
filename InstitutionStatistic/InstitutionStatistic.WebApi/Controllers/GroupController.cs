using AutoMapper;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.ViewObjects;

namespace InstitutionStatistic.WebApi.Controllers;

public class GroupController: BaseController<Group, GroupVO>
{
    public GroupController(IRepository<Group> repository, IMapper mapper) : base(repository, mapper)
    {
    
    }
}
