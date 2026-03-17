using Blocks.FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Application.Features.UploadFile.UploadManuscriptFile;

public record UploadManuscriptFileCommand : ArticleCommand
{
    /// <summary>
    /// The asset type of the file.
    /// </summary>
    [Required]
    public AssetType AssetType { get; set; }
    /// <summary>
    /// the file to be uploaded.
    /// </summary>
    [Required]
    public IFormFile? File { get; set; } = null;

    public override ArticleActionType ActionType => ArticleActionType.UploadAsset;
}

public class UploadManuscriptCommandValidator : ArticleCommandValidator<UploadManuscriptFileCommand>
{
    public UploadManuscriptCommandValidator()
    {
        RuleFor(x => x.File)
            .NotNullWithMessage();

        RuleFor(r => r.AssetType).Must(IsAssetTypeAllowed)
            .WithMessage(x => $"{x.AssetType} not allowed");
    }

    private bool IsAssetTypeAllowed(AssetType assetType) 
        => AllowedAssetTypes.Contains(assetType);

    public IReadOnlyCollection<AssetType> AllowedAssetTypes => new HashSet<AssetType> { AssetType.Manuscript };
}
