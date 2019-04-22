using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BusinessLogic
{
    public class AddPersonMqNotificationHandler : INotificationHandler<AddPersonNotification>
    {
        public Task Handle(AddPersonNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Mq Notification");
            return Task.CompletedTask;
        }
    }
}