using InstitutionStatistic.WebApi.ViewObjects;

namespace InstitutionStatistic.WebApi.Services;

public interface ISpecialityService
{ 
    Task<List<SpecialityVO>> GetTopFive();
}
