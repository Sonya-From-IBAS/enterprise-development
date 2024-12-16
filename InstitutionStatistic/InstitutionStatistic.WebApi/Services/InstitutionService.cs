using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.ViewObjects;
using Microsoft.EntityFrameworkCore;

namespace InstitutionStatistic.WebApi.Services;

public class InstitutionService : IInstitutionService
{
    private IRepository<Institution> _institutionRepository;

    public InstitutionService(IRepository<Institution> institutionRepository)
    {
        _institutionRepository = institutionRepository;

    }

    public async Task<List<DepartmentVO>> GetInstitutionDepartments(string institutionName)
    {
        var query = _institutionRepository.Query();
        var result = await query
            .Where(x => x.Name == institutionName)
            .SelectMany(x => x.Faculties)
            .SelectMany(x => x.Departments)
            .Select(x => new DepartmentVO()
            {
                Id = x.Id,
                Name = x.Name,
                Version = x.Version,
            })
            .ToListAsync();

        return result;
    }

    public async Task<List<FacultyVO>> GetInstitutionFaculties(string instName)
    {
        var query = _institutionRepository.Query();
        var result = await query
            .Where(x => x.Name == instName)
            .Include(x => x.Faculties)
            .SelectMany(x => x.Faculties)
            .Select(x => new FacultyVO()
            {
                Id = x.Id,
                Name = x.Name,
                Version = x.Version,
            })
            .ToListAsync();

        return result;
    }

    public async Task<List<InstitutionVO>> GetInstitutions(InstitutionOwnership institutionOwnership, int groupsCount)
    {
        var query = _institutionRepository.Query();
        var result = await query
            .Where(x => x.InstitutionOwnership == institutionOwnership)
            .Include(x => x.Faculties)
            .ThenInclude(x => x.Departments)
            .ThenInclude(x => x.Groups)
            .Where(x => x.Faculties.Sum(y => y.Departments.Sum(z => z.Groups.Count)) == groupsCount)
            .Select(x => new InstitutionVO()
            {
                Id = x.Id,
                Name = x.Name,
                Version = x.Version,
                RegistrationNumber = x.RegistrationNumber,
                Address = x.Address,
                BuildingOwnership = x.BuildingOwnership,
                InstitutionOwnership = x.InstitutionOwnership
            })
            .ToListAsync();

        return result;
    }

    public async Task<List<SpecialityVO>> GetInstitutionSpecialities(string institutionName)
    {
        var query = _institutionRepository.Query();
        var result = await query
         .Where(x => x.Name == institutionName)
         .Include(x => x.Faculties).ThenInclude(x => x.Departments)
         .SelectMany(x => x.Faculties)
         .SelectMany(x => x.Departments)
         .SelectMany(x => x.Groups)
         .Select(x => x.Speciality)
         .Distinct()
         .Select(x => new SpecialityVO()
         {
             Id = x.Id,
             Name = x.Name,
             Version = x.Version,
             Code = x.Code
         })
         .ToListAsync();

        return result;
    }

    public async Task<List<InstitutionVO>> GetMaxDepartmentInstitutions()
    {
        var query = _institutionRepository.Query();

        var maxDepartmentsCount = await query
            .Include(x => x.Faculties)
            .ThenInclude(x => x.Departments)
            .MaxAsync(x => x.Faculties.Sum(y => y.Departments.Count));

        var result = await query
            .Include(x => x.Faculties)
            .ThenInclude(x => x.Departments)
            .Where(x => x.Faculties.Sum(y => y.Departments.Count) == maxDepartmentsCount)
            .OrderBy(x => x.Name)
            .Select(x => new InstitutionVO()
            {
                Id = x.Id,
                Name = x.Name,
                Version = x.Version,
                RegistrationNumber = x.RegistrationNumber,
                Address = x.Address,
                BuildingOwnership = x.BuildingOwnership,
                InstitutionOwnership = x.InstitutionOwnership
            })
            .ToListAsync();

        return result;
    }

    public async Task<int> GetSpecialitiesCountByOwnership(InstitutionOwnership institutionOwnership, BuildingOwnership buildingOwnership)
    {
        var query = _institutionRepository.Query();

        var result = await query
            .Include(x => x.Faculties)
            .ThenInclude(x => x.Departments)
            .ThenInclude(x => x.Groups)
            .ThenInclude(x => x.Speciality)
            .Where(x => x.InstitutionOwnership == institutionOwnership)
            .Where(x => x.BuildingOwnership == buildingOwnership)
            .SelectMany(x => x.Faculties)
            .SelectMany(faculty => faculty.Departments)
            .SelectMany(department => department.Groups)
            .Select(group => group.Speciality.Name)
            .Distinct()
            .CountAsync();

        return result;
    }
    public async Task<int> GetDepartmentsCountByOwnership(InstitutionOwnership institutionOwnership, BuildingOwnership buildingOwnership)
    {
        var query = _institutionRepository.Query();

        var result = await query
            .Include(x => x.Faculties)
            .ThenInclude(x => x.Departments)
            .Where(x => x.InstitutionOwnership == institutionOwnership)
            .Where(x => x.BuildingOwnership == buildingOwnership)
            .SumAsync(x => x.Faculties.Sum(y => y.Departments.Count));

        return result;
    }

    public async Task<int> GetFacultiesCountByOwnership(InstitutionOwnership institutionOwnership, BuildingOwnership buildingOwnership)
    {
        var query = _institutionRepository.Query();

        var result = await query
            .Include(x => x.Faculties)
            .Where(x => x.InstitutionOwnership == institutionOwnership)
            .Where(x => x.BuildingOwnership == buildingOwnership)
            .SumAsync(x => x.Faculties.Count);

        return result;
    }
}
