using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => o.SwaggerDoc("v1", new() { Title = "Counter API", Version = "v1" }));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCloudEvents();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapSubscribeHandler());

var dapr = new DaprClientBuilder().Build();

app.MapGet("/", async () => await dapr.GetStateAsync<int>("statestore", "counter"));

app.MapPost("/counter", async ([FromBody] int counter) =>
{
    var newCounter = counter * counter;
    Console.WriteLine($"Updating counter: {newCounter}");
    await dapr.SaveStateAsync("statestore", "counter", newCounter);
    return Results.Accepted("/", newCounter);
}).WithTopic("pubsub", "counter");

app.Run();
