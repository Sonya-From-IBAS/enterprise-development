using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.Domain.Models;


namespace InstitutionStatistic.Domain.Queries;
/// <summary>
/// Запросы об университетах
/// </summary>
public class InstitutinQuery: GetInfoQuery<Institution>, IInstitutionQuery
{
    public List<Faculty> GetInstitutionFaculties<T>(IEnumerable<Institution> collection, Func<Institution, T> selector, T value)
    {
        return collection
            .Where(x => selector(x)?.Equals(value) == true)
            .SelectMany(x => x.Faculties)
            .ToList();
    }

    public List<Department> GetInstitutionDepartments<T>(IEnumerable<Institution> collection, Func<Institution, T> selector, T value)
    {
        return collection
            .Where(x => selector(x)?.Equals(value) == true)
            .SelectMany(x => x.Faculties)
            .SelectMany(x => x.Departments)
            .ToList();
    }

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

    public List<Institution> GetMaxDepartmentInstitutions(IEnumerable<Institution> collection)
    {
        var maxDepartmentsCount = collection
            .Max(x => x.Faculties.Sum(y => y.Departments.Count));

        return collection
            .Where(x => x.Faculties.Sum(y => y.Departments.Count) == maxDepartmentsCount)
            .OrderBy(x => x.Name)
            .ToList();
    }

    public List<Institution> GetInstitutions(IEnumerable<Institution> collection, InstitutionOwnership institutionOwnership, int groupsCount)
    {
        return collection
            .Where(x => x.InstitutionOwnership == institutionOwnership)
            .Where(x => x.Faculties.Sum(y => y.Departments.Sum(z => z.Groups.Count)) == groupsCount)
            .ToList();
    }

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
