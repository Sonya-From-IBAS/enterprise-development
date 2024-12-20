using AutoMapper;
using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.Domain.Queries;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.ViewObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InstitutionStatistic.WebApi.Controllers;


public class InstitutionController(
    IRepository<Institution> institutionRepository,
    IMapper mapper,
    IInstitutionQuery instQuery
        ) : BaseController<Institution, InstitutionVO>(institutionRepository, mapper)
{

    /// <summary>
    /// Вывести информацию о факультетах данного института
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpGet("GetInstitutionFaculties")]
    public async Task<ActionResult<List<FacultyVO>>> GetInstitutionFaculties(string institutionName)
    {
        var query = await institutionRepository
            .Query()
            .Include(x => x.Faculties)
            .ToListAsync();

        return Ok(mapper.Map<List<FacultyVO>>(instQuery.GetInstitutionFaculties(query, x => x.Name, institutionName)));
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
        var query = await institutionRepository
            .Query()
            .Include(x => x.Faculties)
            .ThenInclude(x => x.Departments)
            .ToListAsync();

        return Ok(mapper.Map<List<DepartmentVO>>(instQuery.GetInstitutionDepartments(query, x => x.Name, institutionName)));
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
        var query = await institutionRepository.Query()
         .Include(x => x.Faculties)
         .ThenInclude(x => x.Departments)
         .ToListAsync();

        return Ok(mapper.Map<List<SpecialityVO>>(instQuery.GetInstitutionSpecialities(query, x => x.Name, institutionName)));
    }

    /// <summary>
    /// Получить вузы с максимальным кол-ом кафедр, упорядочить по названию
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetMaxDepartmentInstitutions")]
    public async Task<ActionResult<List<InstitutionVO>>> GetMaxDepartmentInstitutions()
    {
        var query = await institutionRepository
            .Query()
            .Include(x => x.Faculties)
            .ThenInclude(x => x.Departments)
            .ToListAsync();

        return Ok(mapper.Map<List<InstitutionVO>>(instQuery.GetMaxDepartmentInstitutions(query)));
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
        var query = await institutionRepository
            .Query()
            .Include(x => x.Faculties)
            .ThenInclude(x => x.Departments)
            .ThenInclude(x => x.Groups)
            .ToListAsync();

        return Ok(mapper.Map<List<FacultyVO>>(instQuery.GetInstitutions(query, institutionOwnership, groupsCount)));
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
        var query = await institutionRepository
            .Query()
            .Include(x => x.Faculties)
            .ToListAsync();

        return Ok(instQuery.GetFacultiesCountByOwnership(query, institutionOwnership, buildingOwnership));
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

        var query = await institutionRepository
            .Query()
            .Include(x => x.Faculties)
            .ThenInclude(x => x.Departments)
            .ToListAsync();

        return Ok(instQuery.GetDepartmentsCountByOwnership(query, institutionOwnership, buildingOwnership));
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
        var query = await institutionRepository
            .Query()
            .Include(x => x.Faculties)
            .ThenInclude(x => x.Departments)
            .ThenInclude(x => x.Groups)
            .ThenInclude(x => x.Speciality)
            .ToListAsync();

        return Ok(instQuery.GetSpecialitiesCountByOwnership(query, institutionOwnership, buildingOwnership));
    }
}
