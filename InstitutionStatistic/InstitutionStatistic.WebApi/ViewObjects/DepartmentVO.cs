using InstitutionStatistic.Domain.Models;

namespace InstitutionStatistic.WebApi.ViewObjects;

public class DepartmentVO: EntityWithNameVO
{
    public FacultyVO? Faculty { get; set; }

    public ICollection<GroupVO>? Groups { get; set; }
}
