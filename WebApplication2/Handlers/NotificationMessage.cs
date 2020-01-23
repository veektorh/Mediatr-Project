using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;



namespace WebApplication2.Handlers
{
    public class NotificationMessage : INotification
    {
        public string message { get; set; }
    }

    public class NotificationHandler : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine($"Debugging from Notifier 1. Message  : {notification.message} ");

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------");

            return Task.CompletedTask;
        }
        

    }

    public class NotificationHandler2 : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine($"Debugging from Notifier 2. Message  : {notification.message} ");

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------------------");
            
            return Task.CompletedTask;
        }


    }



}
