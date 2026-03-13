using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Domain.Entities;

public partial class Author : Person
{
    public string? Degree { get; init; }
    public string? Discipline { get; set; }
}
