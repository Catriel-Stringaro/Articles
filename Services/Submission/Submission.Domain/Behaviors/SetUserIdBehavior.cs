using Blocks.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Domain.Behaviors;

//Pipline behavior
public class SetUserIdBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest,TResponse>
    where TRequest : IAuditableAction
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellation)
    {
        request.CreatedById = 1;

        return await next();
    }
}
