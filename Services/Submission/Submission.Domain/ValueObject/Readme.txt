Value Objects vs Primitives in Domain-Driven Design
The core question is: does this value have meaning beyond its raw type?

Use a Value Object when...
1. The value has validation rules / invariants
If a raw primitive can hold invalid states, wrap it.
csharp// ❌ Primitive - nothing stops "" or "notanemail"
public string Email { get; set; }

// ✅ Value Object - self-validating
public class Email
{
    public string Value { get; }
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
            throw new DomainException("Invalid email");
        Value = value.ToLowerInvariant();
    }
}

2. The value is composed of multiple fields that belong together
If fields only make sense as a unit, they're a value object.
csharp// ❌ Fields scattered on the entity — they're meaningless alone
public string Street { get; set; }
public string City { get; set; }
public string PostalCode { get; set; }
public string Country { get; set; }

// ✅ Address is a cohesive concept
public class Address
{
    public string Street { get; }
    public string City { get; }
    public string PostalCode { get; }
    public string Country { get; }
}

3. Equality is based on value, not identity
Entities are equal by ID. Value objects are equal when all their properties match.
csharppublic class Money
{
    public decimal Amount { get; }
    public string Currency { get; }

    // Two Money(100, "EUR") instances ARE equal — no identity needed
    public override bool Equals(object obj) =>
        obj is Money m && m.Amount == Amount && m.Currency == Currency;
}

4. The value has domain behavior / logic
If you find yourself writing static helpers or extension methods for a primitive, it belongs in a value object.
csharppublic class Money
{
    public Money Add(Money other)
    {
        if (other.Currency != Currency)
            throw new DomainException("Currency mismatch");
        return new Money(Amount + other.Amount, Currency);
    }

    public Money ApplyDiscount(Percentage discount) =>
        new Money(Amount * (1 - discount.Value), Currency);
}

5. The value has meaningful formatting or conversion
csharppublic class PhoneNumber
{
    public string Value { get; }
    public string CountryCode { get; }

    public override string ToString() => $"+{CountryCode} {Value}";
}
```

---

## Stay with a primitive when...

- It's a truly **simple, universally understood value** with no rules (`bool IsActive`, `int SortOrder`)
- There's **no behavior** or **no validation** specific to your domain
- It's only used in **one place** and wrapping it adds no clarity
- It's a **pure infrastructure concern** (e.g., a database row version/timestamp)

---

## Quick Decision Guide
```
Does it have validation rules?              → Value Object
Is it made of multiple related fields?      → Value Object
Does it have domain operations/behavior?    → Value Object
Is equality by value, not by ID?            → Value Object
Is it a simple flag or counter with no rules? → Primitive

Key Properties a Value Object Must Have
PropertyMeaningImmutableNever modified after creation — produce new instances insteadSelf-validatingInvalid state cannot be constructedNo identityNo ID field — equality is structuralReplaceableYou replace the whole object, never mutate a field
The biggest smell that tells you a Value Object is missing is Primitive Obsession — when your entity has many raw string, decimal, or int fields that actually carry domain meaning.