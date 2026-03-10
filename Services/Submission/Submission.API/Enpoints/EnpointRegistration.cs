namespace Submission.API.Enpoints
{
    public static class EnpointRegistration
    {
        public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app) {
            CreateArticleEndpoint.Map(app);

            return app;
        }
    }
}
