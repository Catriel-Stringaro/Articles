using Articles.Abstractions.Enums;
using Blocks.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Submission.Domain.Entities;
using Submission.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<SubmissionDbContext>((provider, options) =>
        {

        });

        services.AddScoped(typeof(Repository<>)); // we need the repositoy from the submission not from blocks, cuz we create this repository specificly for submition, and only acepts 1 parameter, not 2 like the other one.
        services.AddScoped(typeof(ArticleRepository));
        services.AddScoped<CachedRepository<SubmissionDbContext, AssetTypeDefinition, AssetType>>();
        return services;
    }
}
