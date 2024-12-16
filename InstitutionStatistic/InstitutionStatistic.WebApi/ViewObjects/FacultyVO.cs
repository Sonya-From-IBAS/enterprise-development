using InstitutionStatistic.Domain.Models;

namespace InstitutionStatistic.WebApi.ViewObjects;

public class FacultyVO: EntityWithNameVO
{
    public  InstitutionVO? Institution { get; set; }

    public  ICollection<DepartmentVO>? Departments { get; set; }
}
