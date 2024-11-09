using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionStatistic.Domain.Models;

/// <summary>
/// Реализация ректора
/// </summary>
public class Rector(
        ScientificDegree scientificDegree,
        AcademicRank academicRank) : Entity
{
    /// <summary>
    /// ФИО
    /// </summary>
    [Column("full_name")]
    required public string FullName { get; set; }

    /// <summary>
    /// Научная степень
    /// </summary>
    [Column("degree")]
    public ScientificDegree? Degree { get; set; } = scientificDegree;

    /// <summary>
    /// Звание
    /// </summary>
    [Column("rank")]
    public AcademicRank? Rank { get; set; } = academicRank;

}
