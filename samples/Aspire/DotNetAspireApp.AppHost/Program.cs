// Licensed to LuizCarlosFaria, gaGO.io, Mensageria .NET, Cloud Native .NET and ACADEMIA.DEV under one or more agreements.
// The ACADEMIA.DEV licenses this file to you under the MIT license.

using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");

var username = builder.AddParameter("rabbitmq-username");
var password = builder.AddParameter("rabbitmq-password", secret: true);


var rabbitmq = builder.AddRabbitMQ("rabbitmq", username, password)
    .WithManagementPlugin();

var apiService = builder.AddProject<Projects.DotNetAspireApp_ApiService>("apiservice")
    .WithReference(rabbitmq);

builder.AddProject<Projects.DotNetAspireApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(redis)
    .WithReference(apiService);

builder.AddProject<Projects.DotNetAspireApp_Worker>("worker")
    .WithReference(rabbitmq);

builder.Build().Run();
