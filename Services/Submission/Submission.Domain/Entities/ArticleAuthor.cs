using Articles.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Domain.Entities;

public class ArticleAuthor : ArticleActor
{
    public HashSet<ContributionArea> ContributionAreas { get; init; } = null!;
    /*
        What do we want to accomplish here is basically to store 
        this list into a column in the database.

        So basically we need to serialize this list into a single column.
     */
}
