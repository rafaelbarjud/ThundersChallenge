

using FluentValidation;
using ThundersChallenge.Domain.Enum;

namespace ThundersChallenge.Domain.Models.Validators;

public class BusinessTaskValidator : AbstractValidator<BusinessTask>
{
    public BusinessTaskValidator()
    {
        RuleFor(prop => prop.Name)
            .Cascade(CascadeMode.Continue)
            .NotEmpty()
            .WithMessage("The property Name is mandatory.");

        RuleFor(prop => prop.Status)
            .Cascade(CascadeMode.Continue)
            .Must(prop => System.Enum.IsDefined(typeof(BusinessTaskStatus), prop));

        RuleFor(prop => prop.Responsible)
            .Cascade(CascadeMode.Continue)
            .NotEmpty()
            .WithMessage("The property Responsible is mandatory.");

    }

    
    
}
