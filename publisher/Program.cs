// See https://aka.ms/new-console-template for more information
using Dapr.Client;
using System.Threading.Tasks;

var dapr = new DaprClientBuilder().Build();

int currentCount = 0;
while (true)
{
    currentCount++;
    Console.WriteLine($"Publishing counter: {currentCount}");
    await dapr.PublishEventAsync("pubsub", "counter", currentCount);
    await Task.Delay(5000);
}