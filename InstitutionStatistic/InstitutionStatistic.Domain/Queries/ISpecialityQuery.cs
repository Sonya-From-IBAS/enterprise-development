using InstitutionStatistic.Domain.Models;

namespace InstitutionStatistic.Domain.Queries;

public interface ISpecialityQuery: IGetInfoQuery<Speciality>
{
    /// <summary>
    /// Получить топ 5 специальностей
    /// </summary>
    /// <returns></returns>
    public List<Speciality> GetTopFiveSpecialities(IEnumerable<Speciality> collection);
}
