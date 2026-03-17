using Microsoft.EntityFrameworkCore;
using Submission.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Persistance
{
    public class SubmissionDbContext(DbContextOptions<SubmissionDbContext> options) : DbContext(options)
    {
        #region Entities
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Journal> Journals { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<ArticleActor> ArticleActors { get; set; }

        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<AssetTypeDefinition> AssetsTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
