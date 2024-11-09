﻿using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.Domain.Models.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitutionStatistic.Domain.Models;

/// <summary>
/// Реализация сущности институт
/// </summary>
public class Institution(
        Rector rector,
        BuildingOwnership buildingOwnership,
        InstitutionOwnership institutionOwnership) : EntityWithName
{
    /// <summary>
    /// Регистрационный номер
    /// </summary>
    [Column("registration_number")]
    required public string RegistrationNumber { get; set; }

    /// <summary>
    /// Адрес
    /// </summary>
    [Column("address")]
    required public string Address { get; set; } //адрес можно сделать отдельной сущностью, но для лабы это перебор

    /// <summary>
    /// Ректор
    /// </summary>
    public virtual Rector? Rector { get; set; } = rector;

    /// <summary>
    /// Факультеты
    /// </summary>
    public virtual ICollection<Faculty> Faculties { get; set; } = [];

    /// <summary>
    /// Собственность зданий
    /// </summary>
    [Column("building_ownership")]
    public BuildingOwnership? BuildingOwnership { get; set; } = buildingOwnership;

    /// <summary>
    /// Собственность учреждения
    /// </summary>
    [Column("institution_ownership")]
    public InstitutionOwnership? InstitutionOwnership { get; set; } = institutionOwnership;
}
