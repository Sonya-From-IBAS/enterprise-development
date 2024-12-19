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

        CreateMap<DepartmentVO, Department>();
        CreateMap<FacultyVO, Faculty>();
        CreateMap<GroupVO, GroupVO>();
        CreateMap<InstitutionVO, Institution>();
        CreateMap<RectorVO, Rector>();
        CreateMap<SpecialityVO, Speciality>();
    }
}
