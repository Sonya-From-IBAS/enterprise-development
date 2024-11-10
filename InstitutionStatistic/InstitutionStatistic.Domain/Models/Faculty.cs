using InstitutionStatistic.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionStatistic.Domain.Models;

/// <summary>
/// Реализация сущности факультет
/// </summary>
[Table("faculty")]
public class Faculty : EntityWithName
{

    /// <summary>
    /// Институт
    /// </summary>
    public virtual Institution? Institution { get; set; }

    /// <summary>
    /// Кафедры
    /// </summary>
    public virtual ICollection<Department> Departments { get; set; } = [];

}
