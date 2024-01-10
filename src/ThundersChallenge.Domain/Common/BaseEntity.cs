

using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ThundersChallenge.Domain.Common;

public abstract class BaseEntity
{
    protected BaseEntity(Guid? createdBy, Guid? updatedBy, DateTimeOffset? created, DateTimeOffset? updated) 
    { 
        Id = Guid.NewGuid();
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
        Created = created ?? DateTime.UtcNow;
        Updated = updated ?? DateTime.UtcNow;
    }

    public Guid Id { get; protected set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTimeOffset? Created { get; set; }
    public DateTimeOffset? Updated { get; set; }

    [NotMapped]
    [JsonIgnore]
    public bool Valid { get; private set; }
    [NotMapped]
    [JsonIgnore]
    public bool Invalid => !Valid;
    [NotMapped]
    [JsonIgnore]
    public ValidationResult ValidationResult { get; private set; }

    public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
    {
        ValidationResult = validator.Validate(model);
        return Valid = ValidationResult.IsValid;
    }

    public void SetId(Guid id)
    {
        this.Id = id;
    }
}
