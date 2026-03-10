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
    /* 
     * instead of apply IEntityTypeConfiguration<Journal> and create 
     * 
     * builder.HasKey(e => e.Id);
     * builder.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnOrder(0);
     * 
     * creamos EntityConfiguration in the blocks cuz its repeated.
     * next we need to override the configure method and use base.Configure(builder);.
    */
    public class JournalEntityConfiguration : EntityConfiguration<Journal>
    {
        public override void Configure(EntityTypeBuilder<Journal> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).HasMaxLength(64).IsRequired();
            builder.Property(e => e.Abbreviation).HasMaxLength(8).IsRequired();
        }
    }
}
