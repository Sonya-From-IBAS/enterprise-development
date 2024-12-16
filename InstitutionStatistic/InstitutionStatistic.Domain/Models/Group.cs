using InstitutionStatistic.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionStatistic.Domain.Models;

/// <summary>
/// Реализация сущности группа
/// </summary>
[Table("group")]
public class Group : Entity
{
    /// <summary>
    /// Номер группы
    /// </summary>
    [Column("number")]
    required public string Number { get; set; }

    /// <summary>
    /// Кафедра
    /// </summary>
    public virtual Department? Department { get; set; }

    /// <summary>
    /// Специальность
    /// </summary>
    [Column("speciality_id")]
    public virtual Speciality? Speciality { get; set; }

}
