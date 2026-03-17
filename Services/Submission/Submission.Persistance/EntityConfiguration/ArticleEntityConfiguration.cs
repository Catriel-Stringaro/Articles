using Blocks.EntityFramework;
using Blocks.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Submission.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Persistance.EntityConfiguration
{
    public class ArticleEntityConfiguration : EntityConfiguration<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Title).HasMaxLength(256).IsRequired();
            builder.Property(e => e.Scope).HasMaxLength(2048).IsRequired();

            //builder.Property(e => e.stage)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (ArticleStage)Enum.Parse(typeof(ArticleStage), v)
            //    );

            /// change the previous to HasEnumConversion()

            builder.Property(e => e.Stage).HasEnumConversion().IsRequired();
            builder.Property(e => e.Type).HasEnumConversion().IsRequired();
            builder.HasOne(e => e.Journal).WithMany(e => e.Articles)
                .HasForeignKey(e => e.JournalId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Assets).WithOne(e => e.Article)
                .HasForeignKey(e => e.ArticleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
