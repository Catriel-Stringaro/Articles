using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Submission.Domain.Entities;

namespace Submission.Persistence.EntityConfigurations;

// since the author inherit person, is not a separate entity with it own table
// that means we cannot use the base EntityConfiguration<T> Class
// cuz it will wrongly create a new table.
internal class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
				builder.Property(e => e.Discipline).HasMaxLength(64)
						.HasComment("The author's main field of study or research (e.g., Biology, Computer Science).");
				builder.Property(e => e.Degree).HasMaxLength(512)
						.HasComment("The author's highest academic qualification (e.g., PhD in Mathematics, MSc in Chemistry).");
		}
}