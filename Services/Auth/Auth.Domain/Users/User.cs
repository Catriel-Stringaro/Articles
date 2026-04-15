using Auth.Domain.Persons;
using Auth.Domain.Persons.ValueObjects;
using Blocks.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Auth.Domain.Users;

public partial class User : IdentityUser<int>, IEntity
{
    public DateTime RegistrationDate { get; init; } = DateTime.UtcNow;
    public DateTime? LastLogin { get; set; }

    public int PersonId { get; set; }
    public Person Person { get; init; } = null!;

    // control the way we are adding or removing roles while we are creating the user
    //  control the way we are managing roles throw our behaviours
    // instead of public virtual List<UserRole> UserRoles => new();
    // do this:
    private List<UserRole> _userRoles = new ();
    public virtual IReadOnlyList<UserRole> UserRoles => _userRoles;
    //----------------------
    private List<RefreshToken> _refreshTokens = new ();
    public virtual IReadOnlyList<RefreshToken> RefreshTokens => _refreshTokens;
}