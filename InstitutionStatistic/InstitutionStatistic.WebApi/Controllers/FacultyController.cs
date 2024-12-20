﻿using AutoMapper;
using InstitutionStatistic.Domain.Models;
using InstitutionStatistic.WebApi.Repository;
using InstitutionStatistic.WebApi.ViewObjects;

namespace InstitutionStatistic.WebApi.Controllers;

public class FacultyController(IRepository<Faculty> repository, IMapper mapper) : BaseController<Faculty, FacultyVO>(repository, mapper)
{

}
