using Blocks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks.EntityFramework.EntityConfigurations
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnOrder(0);
        }
    }

}
