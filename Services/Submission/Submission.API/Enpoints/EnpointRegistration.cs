using Submission.API.Endpoints;

namespace Submission.API.Enpoints
{
    public static class EnpointRegistration
    {
        public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app) {
            CreateArticleEndpoint.Map(app);
            AssignAuthorEndpoint.Map(app);
            CreateAndAssignAuthorEndpoint.Map(app);

            return app;
        }
    }
}
