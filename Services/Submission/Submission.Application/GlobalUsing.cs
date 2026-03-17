// Third-party libraries
global using MediatR;
global using FluentValidation;

// Internal libraries
global using Blocks.Core;
global using Blocks.MediatR;
global using Articles.Abstractions;
global using Articles.Abstractions.Enums;

// Domain
global using Submission.Domain.Entities;
global using Submission.Domain.Enums;

// Application
global using Submission.Application.Features.Shared;

//Persistence
global using Submission.Persistance.Repositories;

global using AssetTypeDefinitionRepository = Blocks.EntityFrameworkCore.CachedRepository<
        Submission.Persistance.SubmissionDbContext,
        Submission.Domain.Entities.AssetTypeDefinition,
        Articles.Abstractions.Enums.AssetType>;
