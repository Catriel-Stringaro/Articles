when i tried to use:
{
    public static TBuilder RequireRoleAuthorization<TBuilder>(this TBuilder builder, params string[] roles)
        where TBuilder : IEndpointConventionBuilder
        => builder.RequireAuthorization(policy => policy.RequireRole(roles));

I should have an instal of two nugets packages one for IEndpointConventionBuilder and another for RequireAuthorization

but there is another way to do it which is..

add reference to a framework
doing by dobleClick on .csProj class libraty and add a reference to a project
	<ItemGroup>
		<FrameworkReference Include="Microsoft.AspNetCore.App" />
	</ItemGroup>
