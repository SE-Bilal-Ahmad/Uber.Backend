using Redis;
using Redis.Application;
using Redis.Infrastructure;
using Redis.Infrastructure.Services;
using StackExchange.Redis;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGrpcService<MyRedisService>();

app.Run();
