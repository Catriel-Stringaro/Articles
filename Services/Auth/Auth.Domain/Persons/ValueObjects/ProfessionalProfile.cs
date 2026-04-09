using Blocks.Domain.ValueObjects;

namespace Auth.Domain.Persons.ValueObjects;

public sealed class ProfessionalProfile : ValueObject
{
    public string? Position { get; private set; }
    public string? CompanyName { get; private set; }
    public string? Affiliation { get; private set; }

    private ProfessionalProfile() { } // hide the ctor, needed by EF Core

    public static ProfessionalProfile Create(string? position, string? companyName, string? affiliation)
    {
        return new ProfessionalProfile()
        {
            Position = string.IsNullOrWhiteSpace(position) ? null : position.Trim(),
            CompanyName = string.IsNullOrWhiteSpace(companyName) ? null : companyName.Trim(),
            Affiliation = string.IsNullOrWhiteSpace(affiliation) ? null : affiliation.Trim()
        };
    }

    /*
     * So basically by using yield inside this method we can use a foreach together 
     * with get equality components in a foreach.
     * We are taking each item from the enumerable one by one.
     * And this is what we are doing here.
     * Every time we are yielding, it means one item, one iteration in our foreach 
     * and it will be nice also
     */
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Position;
        yield return CompanyName;
        yield return Affiliation;
    }

    public override string ToString() =>
        $"{Position}{(string.IsNullOrEmpty(Position) || string.IsNullOrEmpty(CompanyName) ? "" : " @ ")}{CompanyName}".Trim();
}
