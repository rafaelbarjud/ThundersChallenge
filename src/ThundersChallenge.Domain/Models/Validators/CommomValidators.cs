

using ThundersChallenge.Domain.Enum;

namespace ThundersChallenge.Domain.Models.Validators;

public static class CommomValidators
{
    public static bool BusinessTaskStatusValidator(string value)
    {
        List<string> enumValues = System.Enum.GetValues(typeof(BusinessTaskStatus))
            .Cast<BusinessTaskStatus>()
            .Select(v => v.ToString())
            .ToList();

        return enumValues.Contains(value);
    }
}
