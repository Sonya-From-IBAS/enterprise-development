using InstitutionStatistic.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionStatistic.Domain.Models;

/// <summary>
/// Реализация сущности специальность
/// </summary>
[Table("speciality")]
public class Speciality : EntityWithName
{
    /// <summary>
    /// Код спцеаильности
    /// </summary>
    [Column("code")]
    required public string Code { get; init; }

    /// <summary>
    /// Группы
    /// </summary>
    public virtual ICollection<Group> Groups { get; set; } = [];
}
