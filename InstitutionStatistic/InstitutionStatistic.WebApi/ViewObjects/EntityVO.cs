using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionStatistic.WebApi.ViewObjects;

public class EntityVO
{
    public Guid Id { get; init; }
    public DateTime Version { get; init; }
}
