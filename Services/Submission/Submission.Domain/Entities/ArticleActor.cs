using Articles.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Domain.Entities
{
    public class ArticleActor
    {
        public int ArticleId { get; init; }
        public Article Article { get; init; } = null!;
        public int PersonId { get; init; }
        public Person Person { get; init; } = null!;

        public UserRoleType Role { get; init; }
        public string TypeDiscriminator { get; init; } = null!; // EF discriminator to manage inheritance

    }
}
