namespace ThundersChallenge.Domain.Common;

public class BaseNotification(string key, string message)
{
    public string Key { get; } = key;
    public string Message { get; } = message;
}
