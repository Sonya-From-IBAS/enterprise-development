using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionStatistic.Domain.Models.BaseModel;

/// <summary>
/// Базовый класс для сущности
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    required public Guid Id { get; init; }

    /// <summary>
    /// Version
    /// </summary>
    [Column("version")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    required public DateTime Version { get; init; }
}
