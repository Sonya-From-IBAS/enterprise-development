using InstitutionStatistic.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionStatistic.Domain.Models;
/// <summary>
/// Реализация сущности кафедра
/// </summary>
[Table("department")]
public class Department : EntityWithName
{
    /// <summary>
    /// Факультет
    /// </summary>
    public Faculty? Faculty { get; set; }

    /// <summary>
    /// Группы
    /// </summary>
    public ICollection<Group> Groups { get; set; } = [];

}
