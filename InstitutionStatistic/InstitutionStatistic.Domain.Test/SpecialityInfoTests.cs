using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.Domain.Queries;

namespace InstitutionStatistic.Domain.Test;

/// <summary>
/// тесты для проверки запросов о специальностях
/// </summary>

public class SpecialityInfoTests(TestBase testBase): IClassFixture<TestBase>
{
    private SpecialityQuery _specialitiesQuery = new SpecialityQuery();
    private IEnumerable<Speciality> collection = testBase.Specialities;

    #region Вывести информацию о топ 5 популярных специальностях
    [Fact]
    public void GetTopFiveSpecialitiesTest()
    {
        Assert.Equal(
            _specialitiesQuery.GetTopFiveSpecialities(collection).Select(x => x.Name).ToList(),
            ["SPEC1", "SPEC2", "SPEC3", "SPEC4", "SPEC5"]);
    }
    #endregion
}
