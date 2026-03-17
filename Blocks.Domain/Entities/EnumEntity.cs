namespace Blocks.Domain.Entities;

// EnumEntity give us is the power of work in our app with an enumeration, type safe
// but store the value as an integer
public abstract class EnumEntity<TEnum>  : Entity<TEnum>
    where TEnum : struct, Enum
{
    public TEnum Name { get; init; } = default!;
}
