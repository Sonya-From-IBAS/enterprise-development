using AutoMapper;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.ViewObjects;

namespace InstitutionStatistic.WebApi;

public class AppMappingProfile: Profile
{
    public AppMappingProfile()
    {
        CreateMap<Department, DepartmentVO>();
        CreateMap<Faculty, FacultyVO>();
        CreateMap<Group, GroupVO>();
        CreateMap<Institution, InstitutionVO>();
        CreateMap<Rector, RectorVO>();
        CreateMap<Speciality, SpecialityVO>();
    }
}
