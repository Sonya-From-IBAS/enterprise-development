using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.WebApi.ViewObjects;

namespace InstitutionStatistic.WebApi.Services;

public interface IInstitutionService
{
    Task<List<FacultyVO>> GetInstitutionFaculties(string instName);
    Task<List<DepartmentVO>> GetInstitutionDepartments(string institutionName);
    Task<List<SpecialityVO>> GetInstitutionSpecialities(string institutionName);
    Task<List<InstitutionVO>> GetMaxDepartmentInstitutions();
    Task<List<InstitutionVO>> GetInstitutions(InstitutionOwnership institutionOwnership, int groupsCount);
    int GetFacultiesCountByOwnership(
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership);
    int GetDepartmentsCountByOwnership(
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership);
    int GetSpecialitiesCountByOwnership(
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership);
}
