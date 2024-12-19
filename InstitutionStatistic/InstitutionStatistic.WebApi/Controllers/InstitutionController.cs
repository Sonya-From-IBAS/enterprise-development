using AutoMapper;
using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.Services;
using InstitutionStatistic.WebApi.ViewObjects;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionStatistic.WebApi.Controllers;


public class InstitutionController(IRepository<Institution> institutionRepository,
        IInstitutionService institutionService,
        IMapper mapper) : BaseController<Institution, InstitutionVO>(institutionRepository, mapper)
{

    /// <summary>
    /// Вывести информацию о факультетах данного института
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpGet("GetInstitutionFaculties")]
    public async Task<ActionResult<List<FacultyVO>>> GetInstitutionFaculties(string institutionName)
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

        var result = await institutionService.GetInstitutionFaculties(institutionName);
        return Ok(result);
    }

    /// <summary>
    /// Вывести информацию о кафедрах данного института
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selector"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpGet("GetInstitutionDepartments")]
    public async Task<ActionResult<List<DepartmentVO>>> GetInstitutionDepartments(string institutionName)
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
        var result = await institutionService.GetInstitutionDepartments(institutionName);
        return Ok(result);
    }

    /// <summary>
    /// Вывести информацию о специальностях данного института
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="selector"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpGet("GetInstitutionSpecialities")]
    public async Task<ActionResult<List<SpecialityVO>>> GetInstitutionSpecialities(string institutionName)
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

        var result = await institutionService.GetInstitutionSpecialities(institutionName);
        return Ok(result);
    }

    /// <summary>
    /// Получить вузы с максимальным кол-ом кафедр, упорядочить по названию
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetMaxDepartmentInstitutions")]
    public async Task<ActionResult<List<InstitutionVO>>> GetMaxDepartmentInstitutions()
    {
        var result = await institutionService.GetMaxDepartmentInstitutions();
        return Ok(result);
    }

    /// <summary>
    /// Получить институты с заданной собственностью учреждения и количество групп
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="groupsCount"></param>
    /// <returns></returns>]
    [HttpGet("GetInstitutions")]
    public async Task<ActionResult<List<InstitutionVO>>> GetInstitutions(InstitutionOwnership institutionOwnership, int groupsCount)
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
        var result = await institutionService.GetInstitutions(institutionOwnership, groupsCount);
        return Ok(result);
    }

    /// <summary>
    /// Получить кол-во факультетов по каждому типу собственности учреждения и собственности здания
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="buildingOwnership"></param>
    /// <returns></returns>
    [HttpGet("GetFacultiesCountByOwnership")]
    public async Task<ActionResult<int>> GetFacultiesCountByOwnership(
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership)
    {
        var result = await institutionService.GetFacultiesCountByOwnership(institutionOwnership, buildingOwnership);
        return Ok(result);
    }

    /// <summary>
    /// Получить кол-во кафедр по каждому типу собственности учреждения и собственности здания
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="buildingOwnership"></param>
    /// <returns></returns>
    [HttpGet("GetDepartmentsCountByOwnership")]
    public async Task<ActionResult<int>> GetDepartmentsCountByOwnership(
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership)
    {
        var result = await institutionService.GetDepartmentsCountByOwnership(institutionOwnership, buildingOwnership);
        return Ok(result);
    }

    /// <summary>
    /// Получить кол-во специальностей по каждому типу собственности учреждения и собственности здания
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="buildingOwnership"></param>
    /// <returns></returns>
    [HttpGet("GetSpecialitiesCountByOwnership")]
    public async Task<ActionResult<int>> GetSpecialitiesCountByOwnership(
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership)
    {
        var result = await institutionService.GetSpecialitiesCountByOwnership(institutionOwnership, buildingOwnership);
        return Ok(result);
    }
}
