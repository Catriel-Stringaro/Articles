using Blocks.EntityFramework;
using Submission.Domain.Entities;

namespace Submission.Persistance.Repositories;

/*
 public class ArticleRepository(SubmissionDbContext dbContext) 
    : Repository<SubmissionDbContext, Article>(dbContext)

will change to just a easier exprestion by implementing Repository.cs in the persistance
public class ArticleRepository(SubmissionDbContext dbContext) 
    : Repository<Article>(dbContext)
 */
public class ArticleRepository(SubmissionDbContext dbContext) 
    : Repository<Article>(dbContext)
{
}
