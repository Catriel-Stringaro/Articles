using Submission.Domain.ValueObject;

namespace Submission.Domain.Entities;

public partial class Author
{

    public static new Author Create(string email, string lastName, string firstName, string? title, string affiliation) 
    {
    
        var author = new Author
        {
            EmailAddress = EmailAddress.Create(email),
            FirstName = firstName,
            LastName = lastName,
            Title = title,
            Affiliation = affiliation
        };

        return author;
    }
}