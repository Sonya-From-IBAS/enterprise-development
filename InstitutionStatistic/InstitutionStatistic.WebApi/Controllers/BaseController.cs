using InstitutionStatistic.Domain.Models.BaseModel;
using InstitutionStatistic.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionStatistic.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BaseController<TEntity>: ControllerBase where TEntity : class
{
    private readonly IRepository<TEntity> _repository;

    public BaseController(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<TEntity>> Create(TEntity entity)
    {
        await _repository.AddAsync(entity);
        return entity;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TEntity>> Read(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TEntity entity)
    {
        if (id != (entity as dynamic).Id)
        {
            return BadRequest();
        }
        await _repository.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
