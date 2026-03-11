using Articles.Abstractions;
using MediatR;
using Submission.Domain.Entities;
using Submission.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Application.Features.CreateArticle
{
    public class CreateArticleCommandHandler(Repository<Journal> _journalRepository) : IRequestHandler<CreateArticleCommand, IdResponse>
    {
        public async Task<IdResponse> Handle(CreateArticleCommand command, CancellationToken cancellation)
        {
            var journal = await _journalRepository.FindByIdAsync(command.JournalId);
            var article = journal.CreateArticle(command.Title, command.ArticleType, command.Scope);

            await _journalRepository.SaveChangesAsync(cancellation);
                // todo - throw exceptionNotFounded

            return new IdResponse(article.Id);
        }
    }
}
