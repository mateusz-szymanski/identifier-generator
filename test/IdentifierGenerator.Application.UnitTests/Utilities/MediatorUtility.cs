using IdentifierGenerator.Application.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentifierGenerator.Application.UnitTests.Utilities
{
    class MediatorUtility
    {
        private readonly ServiceProvider _rootServiceProvider;

        public MediatorUtility(ServiceProvider rootServiceProvider)
        {
            _rootServiceProvider = rootServiceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            using (var serviceScope = _rootServiceProvider.CreateScope())
            {
                var mediator = serviceScope.ServiceProvider.GetRequiredService<IMediator>();
                var response = await mediator.Send(request);

                return response;
            }
        }
    }
}
