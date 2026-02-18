using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.FullStackDevOps_Server>("server")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();

if (builder.Environment.IsDevelopment())
{
    var webfrontend = builder.AddViteApp("webfrontend", "../../app")
        .WithReference(server)
        .WaitFor(server);

    // server.PublishWithContainerFiles(webfrontend, "wwwroot");
}

builder.Build().Run();
