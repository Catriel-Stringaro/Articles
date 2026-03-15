using Blocks.MediatR.Behavior;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Submission.Application.Features.CreateArticle;
using Submission.Domain.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddValidatorsFromAssemblyContaining<CreateArticleCommandValidator>()
            .AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            //optimise like 
            config.AddOpenBehavior(typeof(ValidationBehavior<,>)); // validate firts
            config.AddOpenBehavior(typeof(SetUserIdBehavior<,>)); // then set the id
            // so if the command os not valid we don't need to execute setUserIdbehavior
        });
        return services;
    }
}
