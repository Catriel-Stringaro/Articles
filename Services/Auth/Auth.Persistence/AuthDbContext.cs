using Auth.Domain.Persons;
using Auth.Domain.Roles;
using Auth.Domain.Users;
using Auth.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Persistence;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) :
        IdentityDbContext<User, Role, int>(options)
{
    // no need to add Roles & Users here, they are already in the base class
    public virtual DbSet<Person> Persons { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // we can apply config one by one like
        // builder.ApplyConfiguration( new UserEntityConfiguration() );
        
        // there is a more generic way like having from the assembly:
        builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}

