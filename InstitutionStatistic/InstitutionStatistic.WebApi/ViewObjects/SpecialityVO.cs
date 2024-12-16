using InstitutionStatistic.Domain.Models;

namespace InstitutionStatistic.WebApi.ViewObjects;

public class SpecialityVO: EntityWithNameVO
{
    public string? Code { get; init; }

    public ICollection<GroupVO>? Groups { get; set; }
}
