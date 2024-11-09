using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionStatistic.Domain.Models.BaseModel;

/// <summary>
/// Базовый класс для сущности с именем
/// </summary>
public abstract class EntityWithName : Entity
{
    /// <summary>
    /// Name
    /// </summary>
    [Column("name")]
    required public string Name { get; init; }
}
