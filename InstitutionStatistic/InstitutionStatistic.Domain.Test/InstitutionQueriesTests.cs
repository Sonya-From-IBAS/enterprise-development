using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.Domain.Queries;

namespace InstitutionStatistic.Domain.Test;

/// <summary>
/// тесты для проверки запросов об институтах
/// </summary>
public class InstitutionQueriesTests(TestBase testBase) : IClassFixture<TestBase>
{
    private InstitutinQuery _institutinQuery = new InstitutinQuery();
    private IEnumerable<Institution> collection = testBase.Institutions;
    private TestBase _testBase = testBase;

    #region Вывести информацию о выбранном вузе
    [Fact]
    public void GetInstitutionInfoTest()
    {
        var ssau = "СГАУ";
        var pguty = "ПГУТИ";
        var notExisted = "notExisted";

        Assert.Equal(_institutinQuery.GetByName(collection, ssau), _testBase.Institutions[0]);
        Assert.Equal(_institutinQuery.GetByName(collection, pguty), _testBase.Institutions[2]);
        Assert.Null(_institutinQuery.GetByName(collection, notExisted));
    }
    #endregion

    #region Вывести информацию о факультетах, кафедрах и специальностях данного вуза
    [Theory]
    [InlineData("СГАУ", new[] { "FC1", "FC2" })]
    [InlineData("ПГУТИ", new[] { "FC4" })]
    public void GetInstitutionFacultiesTest(string name, string[] expected)
    {
        Assert.Equal(
            _institutinQuery.GetInstitutionFaculties(collection, x => x.Name, name).Select(x => x.Name).ToList(),
            expected);
    }

    [Theory]
    [InlineData("СГАУ", new string[] { "SPEC1", "SPEC2", "SPEC3" })]
    [InlineData("ПГУТИ", new string[] { "SPEC1", "SPEC2", "SPEC3", "SPEC4" })]
    public void GetInstitutionSpecialitiesTest(string name, string[] expected)
    {
        Assert.Equal(
            _institutinQuery.GetInstitutionSpecialities(collection, x => x.Name, name).Select(x => x.Name).ToList(),
            expected);
    }

    [Theory]
    [InlineData("СГАУ", new string[] { "ГИИБ", "ИСТ" })]
    [InlineData("ПГУТИ", new string[] { "TEST1", "TEST2" })]
    public void GetInstitutionDepartmentsTest(string name, string[] expected)
    {
        Assert.Equal(
            _institutinQuery.GetInstitutionDepartments(collection, x => x.Name, name).Select(x => x.Name).ToList(),
            expected);
    }
    #endregion

    #region Вывести информацию о ВУЗах с максимальным количеством кафедр, упорядочить по названию
    [Fact]
    public void GetMaxDepartmentInstitutionsTest()
    {
        Assert.Equal(
            _institutinQuery.GetMaxDepartmentInstitutions(collection).Select(x => x.Name).ToList(),
            new List<string> { "ПГУТИ", "СГАУ" });
    }
    #endregion

    #region Вывести информацию о ВУЗах с заданной собственностью учреждения, и количество групп в ВУЗе
    [Fact]
    public void GetInstitutionsTest()
    {
        Assert.Equal(
            _institutinQuery.GetInstitutions(collection, InstitutionOwnership.Municipality, 5).Select(x => x.Name).ToList(),
            new List<string> { "САМГТУ"});
    }
    #endregion

    #region  Вывести информацию о количестве факультетов, кафедр, специальностей по каждому типу собственности учреждения и собственности здания
    [Theory]
    [InlineData(InstitutionOwnership.Municipality, BuildingOwnership.Municipality, 1)]
    [InlineData(InstitutionOwnership.Municipality, BuildingOwnership.Federal, 2)]
    public void GetFacultiesCountByOwnershipTest(InstitutionOwnership institutionOwnership, BuildingOwnership buildingOwnership, int expectedResult)
    {
        Assert.Equal(_institutinQuery.GetFacultiesCountByOwnership(collection, institutionOwnership, buildingOwnership), expectedResult);
    }

    [Theory]
    [InlineData(InstitutionOwnership.Personal, BuildingOwnership.Personal, 2)]
    [InlineData(InstitutionOwnership.Personal, BuildingOwnership.Federal, 1)]
    public void GetDepartmentsCountByOwnershipTest(InstitutionOwnership institutionOwnership, BuildingOwnership buildingOwnership, int expectedResult)
    {
        Assert.Equal(_institutinQuery.GetDepartmentsCountByOwnership(collection, institutionOwnership, buildingOwnership), expectedResult);
    }

    [Theory]
    [InlineData(InstitutionOwnership.Municipality, BuildingOwnership.Federal, 3)]
    [InlineData(InstitutionOwnership.Municipality, BuildingOwnership.Municipality, 4)]
    public void GetSpecialitiesCountByOwnershipTest(InstitutionOwnership institutionOwnership, BuildingOwnership buildingOwnership, int expectedResult)
    {
        Assert.Equal(_institutinQuery.GetSpecialitiesCountByOwnership(collection, institutionOwnership, buildingOwnership), expectedResult);
    }
    #endregion
}
