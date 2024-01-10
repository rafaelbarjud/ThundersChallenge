
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ThundersChallenge.Domain.Enum;


public enum BusinessTaskStatus
{
    Created,
    Canceled,
    InProgress,
    Completed
}
