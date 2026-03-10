using Microsoft.EntityFrameworkCore;
using Submission.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Persistance
{
    public class SubmissionDbContext : DbContext
    {
        #region Entities
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Journal> Journals { get; set; }
        #endregion
    }
}
