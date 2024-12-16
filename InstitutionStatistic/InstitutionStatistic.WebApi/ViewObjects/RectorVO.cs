using InstitutionStatistic.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionStatistic.WebApi.ViewObjects;

public class RectorVO : EntityVO
{
    public string? FullName { get; set; }

    public ScientificDegree? Degree { get; set; }

    public AcademicRank? Rank { get; set; }
}
