

using MediatR;
using ThundersChallenge.Application.Notification;
using ThundersChallenge.Domain.Models;
using ThundersChallenge.Infra.Repository.Interface;

namespace ThundersChallenge.Application.Tasks;

public class BusinessTaskCommandHandler(NotificationContext notificationContext, IGenericRepository<BusinessTask> repository) :
    IRequestHandler<CreateBusinessTaskByListCommand>,
    IRequestHandler<CreateBusinessTaskCommand>,
    IRequestHandler<UpdateBussinesTaskCommand>

{
    

    public async Task Handle(CreateBusinessTaskByListCommand request, CancellationToken cancellationToken)
    {
      
        request.Tasks.ForEach(taskToValidate =>
        {
            BusinessTask businessTask = new(taskToValidate.Name, taskToValidate.Description, taskToValidate.Responsible, createdBy: taskToValidate.CreatedBy, created: DateTime.UtcNow);

            if (businessTask.Invalid)
            {
                notificationContext.AddNotifications(businessTask.ValidationResult);
                return;
            }
        });


        if (notificationContext.Notifications.Any())
            return;

        await Task.Run(() => request.Tasks.ForEach(async taskToValidate =>
        {
            BusinessTask businessTask = new(taskToValidate.Name, 
                taskToValidate.Description, 
                taskToValidate.Responsible, 
                createdBy: taskToValidate.CreatedBy, 
                created: DateTime.UtcNow);

            await repository.CreateAsync(businessTask);
        }), cancellationToken);
        
    }

    public async Task Handle(CreateBusinessTaskCommand request, CancellationToken cancellationToken)
    {
        BusinessTask businessTask = new(request.Name, 
            request.Description, 
            request.Responsible, 
            createdBy: request.CreatedBy, 
            created: DateTime.UtcNow);

        if (businessTask.Invalid)
        {
            notificationContext.AddNotifications(businessTask.ValidationResult);
            return;
        }

        await repository.CreateAsync(businessTask);
    }

    public async Task Handle(UpdateBussinesTaskCommand request, CancellationToken cancellationToken)
    {
        BusinessTask businessTask = new(request.Name,
            request.Description,
            request.Responsible,
            status: request.Status,
            createdBy: request.UpdatedBy,
            updated: DateTime.UtcNow);

        businessTask.SetId(request.Id);

        if (businessTask.Invalid)
        {
            notificationContext.AddNotifications(businessTask.ValidationResult);
            return;
        }

        await repository.UpdateAsync(businessTask);
    }
}
