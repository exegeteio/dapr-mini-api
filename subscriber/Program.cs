using Dapr;
using Dapr.Client;
using Dapr.AspNetCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var dapr = new DaprClientBuilder().Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCloudEvents();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapSubscribeHandler());

app.MapGet("/", async () => await dapr.GetStateAsync<int>("statestore", "counter"));

app.MapPost("/counter", [Topic("pubsub", "counter")] async ([FromBody] int counter) =>
{
    var newCounter = counter * counter;
    Console.WriteLine($"Updating counter: {newCounter}");
    await dapr.SaveStateAsync("statestore", "counter", newCounter);
    return Results.Accepted("/", newCounter);
});

app.Run();
