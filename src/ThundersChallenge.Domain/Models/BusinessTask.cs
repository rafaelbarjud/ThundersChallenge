

using ThundersChallenge.Domain.Common;
using ThundersChallenge.Domain.Enum;
using ThundersChallenge.Domain.Models.Validators;

namespace ThundersChallenge.Domain.Models;

public class BusinessTask : BaseEntity
{
    public BusinessTask(string name,
        string description,
        Guid responsible,
        Guid? createdBy = null,
        Guid? updatedBy = null,
        DateTimeOffset? created = null,
        DateTimeOffset? updated = null,
        BusinessTaskStatus status = BusinessTaskStatus.Created) : base (createdBy, updatedBy, created, updated)
    {

        Name = name;
        Description = description;
        Responsible = responsible;
        Status = status;

        Validate(this, new BusinessTaskValidator());
    }

    public string Name { get; protected set; } 

    public string Description { get; protected set; }

    public Guid Responsible { get; protected set; }

    public BusinessTaskStatus Status { get; protected set; }

   
}
