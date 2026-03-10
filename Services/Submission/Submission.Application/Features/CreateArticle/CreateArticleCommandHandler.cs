using Articles.Abstracions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Application.Features.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, IdResponse>
    {
        public Task<IdResponse> Handle(CreateArticleCommand request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
