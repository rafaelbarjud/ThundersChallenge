

using MediatR;
using ThundersChallenge.Domain.Models;

namespace ThundersChallenge.Application.Tasks;


public class CreateBusinessTaskByListCommand : IRequest
{
    public List<CreateBusinessTaskCommand> Tasks { get; set; }
}


