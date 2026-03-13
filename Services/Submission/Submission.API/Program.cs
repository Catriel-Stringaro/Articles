using Submission.API;
using Submission.API.Enpoints;
using Submission.Application;
using Submission.Persistance;

var builder = WebApplication.CreateBuilder(args);

#region AddServices

builder.Services
    .AddAPIServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddPersistanceServices(builder.Configuration);

#endregion

var app = builder.Build();


#region Use Services
app
    .UseSwagger()
    .UseSwaggerUI()
    .UseRouting();


app.MapAllEndpoints();
// todo migrate - create first migration

if (app.Environment.IsDevelopment())
{
    // todo - seed test data
}

#endregion

app.Run();
