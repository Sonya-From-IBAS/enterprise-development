using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.Domain.Models;


namespace InstitutionStatistic.Domain.Queries;
/// <summary>
/// Запросы об университетах
/// </summary>
public class InstitutinQuery: GetInfoQuery<Institution>
{
    /// <summary>
    /// Вывести информацию о факультетах данного института
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selector"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public List<Faculty> GetInstitutionFaculties<T>(IEnumerable<Institution> collection, Func<Institution, T> selector, T value)
    {
        return collection
            .Where(x => selector(x)?.Equals(value) == true)
            .SelectMany(x => x.Faculties)
            .ToList();
    }

    /// <summary>
    /// Вывести информацию о кафедрах данного института
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selector"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public List<Department> GetInstitutionDepartments<T>(IEnumerable<Institution> collection, Func<Institution, T> selector, T value)
    {
        return collection
            .Where(x => selector(x)?.Equals(value) == true)
            .SelectMany(x => x.Faculties)
            .SelectMany(x => x.Departments)
            .ToList();
    }

    /// <summary>
    /// Вывести информацию о специальностях данного института
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selector"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public List<Speciality> GetInstitutionSpecialities<T>(IEnumerable<Institution> collection, Func<Institution, T> selector, T value)
    {
        return collection
            .Where(x => selector(x)?.Equals(value) == true)
            .SelectMany(x => x.Faculties)
            .SelectMany(x => x.Departments)
            .SelectMany(x => x.Groups)
            .Select(x => x.Speciality)
            .Distinct()
            .ToList();
    }

    /// <summary>
    /// Получить вузы с максимальным кол-ом кафедр, упорядочить по названию
    /// </summary>
    /// <returns></returns>
    public List<Institution> GetMaxDepartmentInstitutions(IEnumerable<Institution> collection)
    {
        var maxDepartmentsCount = collection
            .Max(x => x.Faculties.Sum(y => y.Departments.Count));

        return collection
            .Where(x => x.Faculties.Sum(y => y.Departments.Count) == maxDepartmentsCount)
            .OrderBy(x => x.Name)
            .ToList();
    }

    /// <summary>
    /// Получить институты с заданной собственностью учреждения и количество групп
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="groupsCount"></param>
    /// <returns></returns>
    public List<Institution> GetInstitutions(IEnumerable<Institution> collection, InstitutionOwnership institutionOwnership, int groupsCount)
    {
        return collection
            .Where(x => x.InstitutionOwnership == institutionOwnership)
            .Where(x => x.Faculties.Sum(y => y.Departments.Sum(z => z.Groups.Count)) == groupsCount)
            .ToList();
    }

    /// <summary>
    /// Получить кол-во факультетов по каждому типу собственности учреждения и собственности здания
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="buildingOwnership"></param>
    /// <returns></returns>
    public int GetFacultiesCountByOwnership(
        IEnumerable<Institution> collection,
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership)
    {
        return collection
            .Where(x => x.InstitutionOwnership == institutionOwnership)
            .Where(x => x.BuildingOwnership == buildingOwnership)
            .Sum(x => x.Faculties.Count);
    }

    /// <summary>
    /// Получить кол-во кафедр по каждому типу собственности учреждения и собственности здания
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="buildingOwnership"></param>
    /// <returns></returns>
    public int GetDepartmentsCountByOwnership(
        IEnumerable<Institution> collection,
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership)
    {
        return collection
             .Where(x => x.InstitutionOwnership == institutionOwnership)
             .Where(x => x.BuildingOwnership == buildingOwnership)
             .Sum(x => x.Faculties.Sum(y => y.Departments.Count));
    }

    /// <summary>
    /// Получить кол-во специальностей по каждому типу собственности учреждения и собственности здания
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="buildingOwnership"></param>
    /// <returns></returns>
    public int GetSpecialitiesCountByOwnership(
        IEnumerable<Institution> collection,
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership)
    {
        return collection
            .Where(x => x.InstitutionOwnership == institutionOwnership)
            .Where(x => x.BuildingOwnership == buildingOwnership)
            .SelectMany(x => x.Faculties)
            .SelectMany(faculty => faculty.Departments)
            .SelectMany(department => department.Groups)
            .Select(group => group.Speciality.Name)
            .Distinct()
            .Count();
    }
}
