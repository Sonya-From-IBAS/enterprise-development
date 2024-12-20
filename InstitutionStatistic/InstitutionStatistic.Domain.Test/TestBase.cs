﻿using InstitutionStatistic.Domain.Enums;
using InstitutionStatistic.Domain.Models;

namespace InstitutionStatistic.Domain.Test;

/// <summary>
/// Базовый класс для тестов
/// </summary>
public class TestBase
{
    public List<Institution> Institutions = new List<Institution>();

    public List<Speciality> Specialities = new List<Speciality>();

    /// <summary>
    /// ctor
    /// </summary>
    public TestBase()
    {

        #region Rectors
        var rector1 = new Rector {
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            FullName = "Иванов A.Ю", 
            Degree = ScientificDegree.Candidate, 
            Rank = AcademicRank.AssociateProfessor 
        };
        var rector2 = new Rector { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            FullName = "Петров В.А",
            Degree = ScientificDegree.Doctor,
            Rank = AcademicRank.Professor
        };
        var rector3 = new Rector { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            FullName = "Сидоров Н.П",
            Degree = ScientificDegree.Candidate,
            Rank = AcademicRank.AssociateProfessor
        };
        var rector4 = new Rector { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            FullName = "Бобров А.М",
            Degree = ScientificDegree.Doctor,
            Rank = AcademicRank.Professor
        };
        #endregion

        #region Faculties
        var faclt1 = new Faculty() { Id = Guid.NewGuid(), Version = DateTime.Now, Name = "FC1" };
        var faclt2 = new Faculty() { Id = Guid.NewGuid(), Version = DateTime.Now, Name = "FC2" };
        var faclt3 = new Faculty() { Id = Guid.NewGuid(), Version = DateTime.Now, Name = "FC3" };
        var faclt4 = new Faculty() { Id = Guid.NewGuid(), Version = DateTime.Now, Name = "FC4" };
        var faclt5 = new Faculty() { Id = Guid.NewGuid(), Version = DateTime.Now, Name = "FC5" };
        #endregion

        #region Departments
        var department1 = new Department() { Name = "ГИИБ", Id = Guid.NewGuid(), Version = DateTime.Now };
        var department2 = new Department() { Name = "ИСТ", Id = Guid.NewGuid(), Version = DateTime.Now };
        var department3 = new Department() { Name = "ЛБС", Id = Guid.NewGuid(), Version = DateTime.Now };
        var department4 = new Department() {Name = "TEST1", Id = Guid.NewGuid(), Version = DateTime.Now };
        var department5 = new Department() {Name = "TEST2", Id = Guid.NewGuid(), Version = DateTime.Now };
        var department6 = new Department() {Name = "TEST3", Id = Guid.NewGuid(), Version = DateTime.Now };
        #endregion

        #region Specialities
        var speciality1 = new Speciality() { Name = "SPEC1", Code = "123456", Id = Guid.NewGuid(), Version = DateTime.Now };
        var speciality2 = new Speciality() { Name = "SPEC2", Code = "234567", Id = Guid.NewGuid(), Version = DateTime.Now };
        var speciality3 = new Speciality() { Name = "SPEC3", Code = "345678", Id = Guid.NewGuid(), Version = DateTime.Now };
        var speciality4 = new Speciality() { Name = "SPEC4", Code = "456789", Id = Guid.NewGuid(), Version = DateTime.Now };
        var speciality5 = new Speciality() { Name = "SPEC5", Code = "567890", Id = Guid.NewGuid(), Version = DateTime.Now };
        var speciality6 = new Speciality() { Name = "SPEC6", Code = "678901", Id = Guid.NewGuid(), Version = DateTime.Now };
        #endregion

        #region Groups
        var group1 = new Group {
            Id = Guid.NewGuid(),
            Version = DateTime.Now,
            Number = "6412-100503",
            Department = department1,
            Speciality = speciality1
        };
        var group2 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "6411-100503",
            Department = department2,
            Speciality = speciality2
        };
        var group3 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "6413-100503",
            Department = department2,
            Speciality = speciality3
        };


        var group4 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "6414-100503",
            Department = department3,
            Speciality = speciality1
        };
        var group5 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "5101-100503",
            Department = department3,
            Speciality = speciality2
        };
        var group6 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "5102-100503",
            Department = department3,
            Speciality = speciality3
        };
        var group7 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "5103-100503",
            Department = department3,
            Speciality = speciality4
        };
        var group8 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "5104-100503",
            Department = department3,
            Speciality = speciality1
        };

        var group9 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "3221-100503",
            Department = department4,
            Speciality = speciality1
        };
        var group10 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "3222-100503",
            Department = department4,
            Speciality = speciality2
        };
        var group11 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "3223-100503",
            Department = department4,
            Speciality = speciality3
        };
        var group12 = new Group { 
            Id = Guid.NewGuid(),
            Version  = DateTime.Now, 
            Number = "3223-100503",
            Department = department5,
            Speciality = speciality4
        };
        var group13 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "7405-100503",
            Department = department5,
            Speciality = speciality4
        };


        var group14 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "7406-100503",
            Department = department6,
            Speciality = speciality3
        };
        var group15 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "7407-100503",
            Department = department6,
            Speciality = speciality2
        };
        var group16 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "7408-100503",
            Department = department6,
            Speciality = speciality4
        };


        var group17 = new Group { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Number = "7409-100503",
            Department = department6,
            Speciality = speciality5
        };
        #endregion

        #region Institutions
        var inst1 = new Institution {
            Id = Guid.NewGuid(),
            Version = DateTime.Now,
            Name = "СГАУ",
            RegistrationNumber = "test register1",
            Address = "test address1",
            Rector = rector1,
            BuildingOwnership = BuildingOwnership.Federal,
            InstitutionOwnership = InstitutionOwnership.Municipality
        };

        var inst2 = new Institution { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Name = "САМГТУ", 
            RegistrationNumber = "test register2", 
            Address = "test address2",
            Rector = rector2,
            BuildingOwnership = BuildingOwnership.Municipality,
            InstitutionOwnership = InstitutionOwnership.Municipality
        };

        var inst3 = new Institution { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Name = "ПГУТИ", 
            RegistrationNumber = "test register3", 
            Address = "test address3",
            Rector = rector3,
            BuildingOwnership = BuildingOwnership.Personal,
            InstitutionOwnership = InstitutionOwnership.Personal
        };

        var inst4 = new Institution { 
            Id = Guid.NewGuid(), 
            Version = DateTime.Now, 
            Name = "САМГМУ", 
            RegistrationNumber = "test register4", 
            Address = "test address4",
            Rector = rector4,
            BuildingOwnership = BuildingOwnership.Federal,
            InstitutionOwnership = InstitutionOwnership.Personal
        };
        #endregion

        #region initAllValues
        //первый институт
        inst1.Faculties.Add(faclt1);
        inst1.Faculties.Add(faclt2);

        faclt1.Institution = inst1;
        faclt2.Institution = inst1;

        faclt1.Departments.Add(department1);
        faclt2.Departments.Add(department2);

        department1.Faculty = faclt1;
        department2.Faculty = faclt2;

       
        department1.Groups.Add(group1);
        department2.Groups.Add(group2);
        department2.Groups.Add(group3);


        speciality1.Groups.Add(group1);
        speciality2.Groups.Add(group2);
        speciality3.Groups.Add(group3);

        //воторой институт
        inst2.Faculties.Add(faclt3);

        faclt3.Institution = inst2;

        faclt3.Departments.Add(department3);

        department3.Faculty = faclt3;

        department3.Groups.Add(group4);
        department3.Groups.Add(group5);
        department3.Groups.Add(group6);
        department3.Groups.Add(group7);
        department3.Groups.Add(group8);

        speciality1.Groups.Add(group4);
        speciality1.Groups.Add(group8);
        speciality2.Groups.Add(group5);
        speciality4.Groups.Add(group7);
        speciality3.Groups.Add(group6);

        //третий институт
        inst3.Faculties.Add(faclt4);

        faclt4.Institution = inst3;

        faclt4.Departments.Add(department4);
        faclt4.Departments.Add(department5);

        department4.Faculty = faclt4;
        department5.Faculty = faclt4;

        department4.Groups.Add(group9);
        department4.Groups.Add(group10);
        department4.Groups.Add(group11);
        department5.Groups.Add(group12);
        department5.Groups.Add(group13);

        speciality1.Groups.Add(group9);
        speciality2.Groups.Add(group10);
        speciality3.Groups.Add(group11);
        speciality4.Groups.Add(group12);
        speciality4.Groups.Add(group13);

        //четвертый институт
        inst4.Faculties.Add(faclt5);

        faclt5.Institution = inst4;

        faclt5.Departments.Add(department6);

        department6.Faculty = faclt5;

        department6.Groups.Add(group14);
        department6.Groups.Add(group15);
        department6.Groups.Add(group16);
        department6.Groups.Add(group17);

        speciality3.Groups.Add(group14);
        speciality2.Groups.Add(group15);
        speciality4.Groups.Add(group16);
        speciality5.Groups.Add(group17);
        //Добавляем институты и специальности...
        Institutions.AddRange([inst1, inst2, inst3, inst4]);
        Specialities.AddRange([speciality1, speciality2, speciality3, speciality4, speciality5, speciality6]);
        #endregion
    }
}
