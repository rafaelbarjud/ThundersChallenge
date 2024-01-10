using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThundersChallenge.Application.Tasks;
using ThundersChallenge.Domain.Enum;
using ThundersChallenge.Domain.Models;
using ThundersChallenge.Infra.Repository.Interface;


namespace ThundersChallenge.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BusinessTasksController(IMediator mediator, IGenericRepository<BusinessTask> respository) : ControllerBase
{
    [HttpPost()]
    public async Task<IActionResult> CreateBusinessTask([FromBody] CreateBusinessTaskCommand command)
    {
        await mediator.Send(command);
        return Created("", null);
    }

    [HttpPost("list")]
    public async Task<IActionResult> CreateBusinessByListTask([FromBody] CreateBusinessTaskByListCommand command)
    {
        await mediator.Send(command);
        return Created("", null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBusinessTaskById([FromRoute] Guid id)
    {
        var businessTask = await respository.GetByIdAsync(id);

        if (businessTask != null)
            return Ok(businessTask);

        return NoContent();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllBusinessTask()
    {
        var businessTask = await respository.GetAllAsync();

        if (businessTask.Any()) 
            return Ok(businessTask);

        return NoContent();
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateBusinessTask([FromBody] UpdateBussinesTaskCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBusinessTask([FromRoute] Guid id)
    {
        await respository.DeleteAsync(id);
        return Accepted();
    }
}


