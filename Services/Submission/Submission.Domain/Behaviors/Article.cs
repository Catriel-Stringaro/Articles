using Articles.Abstractions.Enums;
using Blocks.Domain.Entities;
using Blocks.Exceptions;

namespace Submission.Domain.Entities;

public partial class Article
{ 
    public void AssignAuthor(Author author, HashSet<ContributionArea> contributionAreas, bool isCorrespondingAuthor)
    {
        var role = isCorrespondingAuthor ? UserRoleType.CORAUT : UserRoleType.AUT;

        if (Actors.Exists(x => x.PersonId == author.Id && x.Role == role))
            throw new DomainException($"Author {author.EmailAddress} is already assigned to the article");

        Actors.Add(new ArticleAuthor()
        {
            ContributionAreas = contributionAreas,
            Person = author,
            Role = role
        });

        // Todo - create domain event
    }
}
