using Blocks.Domain.Entities;
using Submission.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Domain.Entities;

public class Person : Entity
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string FullName => FirstName + " " + LastName;
    public string? Title { get; init; }
    public required EmailAddress EmailAddress { get; init; }
    public required string Affiliation { get; init; }

    public int? UserId { get; init; }
    public string TypeDiscriminator { get; init; } = null!; // EF discriminator
                                                            // So the EF core can make a difference between our inherited types.
    public List<ArticleActor> ArticleActors { get; set; } = new();
}
