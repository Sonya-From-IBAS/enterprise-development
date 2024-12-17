using AutoMapper;
using InstitutionStatistic.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InstitutionStatistic.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class BaseController<TEntity, TEntityDTO>(IRepository<TEntity> repository, IMapper mapper) : ControllerBase 
    where TEntity : class
    where TEntityDTO : class
{

    [HttpPost]
    public async Task<ActionResult<TEntityDTO>> Create(TEntityDTO entityVO)
    {
        var entity = mapper.Map<TEntity>(entityVO);
        await repository.AddAsync(entity);
        return entityVO;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TEntityDTO>> Read(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(mapper.Map<TEntityDTO>(entity));
    }

    [HttpGet]
    public async Task<ActionResult<List<TEntityDTO>>> ReadAll()
    {
        var entity = await repository.GetAllAsync();
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(mapper.Map<List<TEntityDTO>>(entity));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, TEntityDTO entityVO)
    {
        if (id != (entityVO as dynamic).Id)
        {
            return BadRequest();
        }
        await repository.UpdateAsync(mapper.Map<TEntity>(entityVO));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await repository.DeleteAsync(id);
        return NoContent();
    }
}
