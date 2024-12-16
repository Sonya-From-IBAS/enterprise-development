using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.Services;
using InstitutionStatistic.WebApi.ViewObjects;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionStatistic.WebApi.Controllers;


public class InstitutionController: BaseController<Institution>
{
    private IInstitutionService _institutionService;
    public InstitutionController(
        IRepository<Institution> institutionRepository, 
        IInstitutionService institutionService) : base(institutionRepository)
    {
        _institutionService = institutionService;
    }

    /// <summary>
    /// Вывести информацию о факультетах данного института
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [HttpGet("GetInstitutionFaculties")]
    public async Task<ActionResult<List<FacultyVO>>> GetInstitutionFaculties(string institutionName)
    {
        var result = await _institutionService.GetInstitutionFaculties(institutionName);
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
        var result = await _institutionService.GetInstitutionDepartments(institutionName);
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
        var result = await _institutionService.GetInstitutionSpecialities(institutionName);
        return Ok(result);
    }

    /// <summary>
    /// Получить вузы с максимальным кол-ом кафедр, упорядочить по названию
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetMaxDepartmentInstitutions")]
    public async Task<ActionResult<List<InstitutionVO>>> GetMaxDepartmentInstitutions()
    {
        var result = await _institutionService.GetMaxDepartmentInstitutions();
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
        var result = await _institutionService.GetInstitutions(institutionOwnership, groupsCount);
        return Ok(result);
    }

    /// <summary>
    /// Получить кол-во факультетов по каждому типу собственности учреждения и собственности здания
    /// </summary>
    /// <param name="institutionOwnership"></param>
    /// <param name="buildingOwnership"></param>
    /// <returns></returns>
    [HttpGet("GetFacultiesCountByOwnership")]
    public async ActionResult<int> GetFacultiesCountByOwnership(
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership)
    {
        var result = await _institutionService
        return Repository
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
    [HttpGet("GetDepartmentsCountByOwnership")]
    public ActionResult<int> GetDepartmentsCountByOwnership(
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership)
    {
        return Repository
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
    [HttpGet("GetSpecialitiesCountByOwnership")]
    public ActionResult<int> GetSpecialitiesCountByOwnership(
        InstitutionOwnership institutionOwnership,
        BuildingOwnership buildingOwnership)
    {
        return Repository
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
