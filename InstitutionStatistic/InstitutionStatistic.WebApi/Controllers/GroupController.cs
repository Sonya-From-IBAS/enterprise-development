using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;

namespace InstitutionStatistic.WebApi.Controllers;

public class GroupController: BaseController<Group>
{
    public GroupController(IRepository<Group> repository): base(repository) 
    {
    
    }
}
