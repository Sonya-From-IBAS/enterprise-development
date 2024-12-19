using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.Domain.Models;

namespace InstitutionStatistic.Domain.Queries;

public interface IInstitutionQuery: IGetInfoQuery<Institution>
{
    /// <summary>
    /// Вывести информацию о факультетах данного института
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selector"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    List<Faculty> GetInstitutionFaculties<T>(IEnumerable<Institution> collection, Func<Institution, T> selector, T value);

    /// <summary>
    /// Вывести информацию о кафедрах данного института
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selector"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    List<Department> GetInstitutionDepartments<T>(IEnumerable<Institution> collection, Func<Institution, T> selector, T value);

    /// <summary>
    /// Вывести информацию о специальностях данного института
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selector"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    List<Speciality> GetInstitutionSpecialities<T>(IEnumerable<Institution> collection, Func<Institution, T> selector, T value);

    /// <summary>
    /// Получить вузы с максимальным кол-ом кафедр, упорядочить по названию
    /// </summary>
    /// <returns></returns>
    List<Institution> GetMaxDepartmentInstitutions(IEnumerable<Institution> collection);

    /// <summary>
    /// Получить институты с заданной собственностью учреждения и количество групп
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="groupsCount"></param>
    /// <returns></returns>
    List<Institution> GetInstitutions(IEnumerable<Institution> collection, InstitutionOwnership institutionOwnership, int groupsCount);

    /// <summary>
    /// Получить кол-во факультетов по каждому типу собственности учреждения и собственности здания
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="buildingOwnership"></param>
    /// <returns></returns>
    int GetFacultiesCountByOwnership(
        IEnumerable<Institution> collection,
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership);

    /// <summary>
    /// Получить кол-во кафедр по каждому типу собственности учреждения и собственности здания
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="buildingOwnership"></param>
    /// <returns></returns>
    int GetDepartmentsCountByOwnership(
        IEnumerable<Institution> collection,
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership);

    /// <summary>
    /// Получить кол-во специальностей по каждому типу собственности учреждения и собственности здания
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="buildingOwnership"></param>
    /// <returns></returns>
    int GetSpecialitiesCountByOwnership(
        IEnumerable<Institution> collection,
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership);
}
