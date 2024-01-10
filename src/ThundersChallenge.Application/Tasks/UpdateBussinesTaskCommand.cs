

using MediatR;
using ThundersChallenge.Domain.Enum;

namespace ThundersChallenge.Application.Tasks;

public class UpdateBussinesTaskCommand : BusinessTaskCommand, IRequest
{
    public Guid Id { get; set; }
    public BusinessTaskStatus Status { get; set; }
    public Guid UpdatedBy { get; set; }
}
