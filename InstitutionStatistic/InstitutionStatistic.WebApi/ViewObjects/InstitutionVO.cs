using InstitutionStatistic.Domain.Enums;

namespace InstitutionStatistic.WebApi.ViewObjects;

public class InstitutionVO: EntityWithNameVO
{
    public string? RegistrationNumber { get; set; }

    public string? Address { get; set; }

    public RectorVO? Rector { get; set; }

    public  ICollection<FacultyVO>? Faculties { get; set; }

    public BuildingOwnership? BuildingOwnership { get; set; }

    public InstitutionOwnership? InstitutionOwnership { get; set; }
}
