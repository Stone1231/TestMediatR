using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BusinessLogic
{
    public class AddPersonMailNotificationHandler : INotificationHandler<AddPersonNotification>
    {
        public Task Handle(AddPersonNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Mail Notification");
            return Task.CompletedTask;
        }
    }
}