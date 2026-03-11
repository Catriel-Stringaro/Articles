using Articles.Abstractions.Enums;
using Blocks.Domain.Entities;

namespace Submission.Domain.Entities;

public partial class Journal
{
    public Article CreateArticle(string title, ArticleType type, string scope)
    {
        var article = new Article()
        {
            Title = title,
            Type = type,
            Scope = scope,
            Journal = this,
            Stage = ArticleStage.Created
        };

        _articles.Add(article);
        // todo - add domain even later for posible email notifivaction.
        return article;
    }
}