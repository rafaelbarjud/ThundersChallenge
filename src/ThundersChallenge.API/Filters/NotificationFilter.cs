using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;
using ThundersChallenge.Application.Notification;

namespace ThundersChallenge.API.Filters;

public class NotificationFilter(NotificationContext notificationContext) : IAsyncResultFilter
{
    
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (notificationContext.HasNotifications)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.HttpContext.Response.ContentType = "application/json";

            var notifications = JsonConvert.SerializeObject(new { Messages = notificationContext.Notifications.Select(x => x.Message).ToList() });
            await context.HttpContext.Response.WriteAsync(notifications);

            return;
        }

        await next();
    }
}
