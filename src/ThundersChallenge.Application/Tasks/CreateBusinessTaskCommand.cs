
using MediatR;

namespace ThundersChallenge.Application.Tasks;

public class CreateBusinessTaskCommand : BusinessTaskCommand, IRequest
{
    public Guid CreatedBy { get; set; }
}