using Blocks.Domain.Entities;
using Blocks.EntityFramework;
using Submission.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Persistance.Repositories;

public class Repository<TEntity>(SubmissionDbContext dbContext) : Repository<SubmissionDbContext, TEntity>(dbContext)
    where TEntity : class, IEntity
{
}
