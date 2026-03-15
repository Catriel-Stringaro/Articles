using Articles.Abstractions;
using Articles.Abstractions.Enums;
using Blocks.EntityFramework;
using Blocks.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Submission.Domain.Entities;
using Submission.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Application.Features.CreateArticle;

internal class CreateArticleCommandHandler(Repository<Journal> _journalRepository) : IRequestHandler<CreateArticleCommand, IdResponse>
{
    public async Task<IdResponse> Handle(CreateArticleCommand command, CancellationToken cancellation)
    {
        var journal = await _journalRepository.FindByIdOrThrowAsync(command.JournalId);

        var article = journal.CreateArticle(command.Title, command.ArticleType, command.Scope);

        await AssignCurrentUserAsAuthor(article, command);

        await _journalRepository.SaveChangesAsync(cancellation);
            // todo - throw exceptionNotFounded

        return new IdResponse(article.Id);
    }

    private async Task AssignCurrentUserAsAuthor(Article article, CreateArticleCommand command)
    {
        var author = await _journalRepository.Context.Authors.SingleOrDefaultAsync(t => t.UserId == command.CreatedById);

        if (author is not null)
            article.AssignAuthor(author, [ContributionArea.OriginalDraft], isCorrespondingAuthor: true);
    }
}
