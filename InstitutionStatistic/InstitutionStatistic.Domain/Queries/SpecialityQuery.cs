using InstitutionStatistic.Domain.Models;

namespace InstitutionStatistic.Domain.Queries;


/// <summary>
/// Запросы о специальностях
/// </summary>
public class SpecialityQuery : GetInfoQuery<Speciality>
{

    /// <summary>
    /// Получить топ 5 специальностей
    /// </summary>
    /// <returns></returns>
    public List<Speciality> GetTopFiveSpecialities(IEnumerable<Speciality> collection) =>
        collection.OrderByDescending(x => x.Groups.Count).Take(5).ToList();
}
