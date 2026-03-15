
using Blocks.Domain;

namespace Articles.Abstractions;
// we gonna use this in all our microservices, cuz is about to articles,
// and cuz this particular interface is article dependent be cannot put it in the blocks domain
// we need to put it in the article.Abstractions
public interface IArticleAction : IAuditableAction
{
    int ArticleId { get; }
}

public interface IArticleAction<TActionType> : IAuditableAction<TActionType>, IArticleAction
    where TActionType : Enum;