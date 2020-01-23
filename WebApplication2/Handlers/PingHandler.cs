using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WebApplication2.Handlers
{
    public class Ping : IRequest<string> 
    {
    }

    public class PingHandler2 : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong from ping handler 2");
        }
    }

    public class PingHandler : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }

    
}
