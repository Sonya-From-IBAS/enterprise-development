using InstitutionStatistic.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionStatistic.Domain.Models;

/// <summary>
/// Реализация сущности группа
/// </summary>
public class Group(Department department, Speciality speciality) : Entity
{
    /// <summary>
    /// Номер группы
    /// </summary>
    [Column("number")]
    required public string Number { get; set; }

    /// <summary>
    /// Кафедра
    /// </summary>
    public virtual Department? Department { get; set; } = department;

    /// <summary>
    /// Специальность
    /// </summary>
    public virtual Speciality Speciality { get; set; } = speciality;

}
