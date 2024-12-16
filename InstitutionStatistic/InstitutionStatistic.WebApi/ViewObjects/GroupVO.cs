using InstitutionStatistic.Domain.Models;

namespace InstitutionStatistic.WebApi.ViewObjects;

public class GroupVO: EntityVO
{
    public string? Number { get; set; }

    public DepartmentVO? Department { get; set; }

    public SpecialityVO? Speciality { get; set; }
}
