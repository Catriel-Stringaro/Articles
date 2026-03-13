using Blocks.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Submission.Domain.ValueObject;

public class EmailAddress
{
    public string Value { get; private set; } // set private cuz we want to validate the value and control the way the email address is created

    public EmailAddress(string value) => Value = value;

    public static EmailAddress Create(string value)
    {
        Guard.ThrowIfNullOrWhiteSpace(value);

        if (IsValidEmail(value))
            throw new ArgumentException("Invalid email format.");

        return new EmailAddress(value);
    }

    // valid email is better use libraries but for this we will keep it simple
    private static bool IsValidEmail(string email)
    {
        // Basic email regex for validation
        const string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
    }
}
