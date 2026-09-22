using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.FullStackDevOps_Server>("server")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();

if (builder.Environment.IsDevelopment())
{
    var app = builder.AddViteApp("webfrontend", "../../app")
        .WithReference(server)
        .WaitFor(server);

    // server.PublishWithContainerFiles(app, "wwwroot");
}

builder.Build().Run();
