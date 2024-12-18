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
    /// <summary>
    /// Записать новый объект в бд
    /// </summary>
    /// <param name="entityVO">Новый объект</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<TEntityDTO>> Create(TEntityDTO entityVO)
    {
        var entity = mapper.Map<TEntity>(entityVO);
        await repository.AddAsync(entity);
        return entityVO;
    }

    /// <summary>
    /// Получить объект из бд по айдишнику
    /// </summary>
    /// <param name="id">Айдишник</param>
    /// <returns></returns>
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

    /// <summary>
    /// Получить все объекты
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Обновить объект в бд
    /// </summary>
    /// <param name="id">Айдишник объекта</param>
    /// <param name="entityVO">Новый объект</param>
    /// <returns></returns>
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

    /// <summary>
    /// Удалить объект из бд по айдишнику
    /// </summary>
    /// <param name="id">Айдишник</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await repository.DeleteAsync(id);
        return NoContent();
    }
}
