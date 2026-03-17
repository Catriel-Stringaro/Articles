using Articles.Abstractions.Enums;
using Blocks.Domain.Entities;
using Submission.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Domain.Entities;

public partial class Asset : Entity
{
    public AssetName Name { get; private set; } = null!;
    public AssetType Type { get; private set; }

    public int ArticleId { get; private set; }
    public virtual Article Article { get; private set; } = null!;

    public File File { get; set; } = null!;
}
