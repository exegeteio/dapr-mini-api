# Dapr Mini API

This is my personal playground for experimenting with
[Dapr](https://dapr.io)
and the .NET 6.0
[Minimal APIs](https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-4/#introducing-minimal-apis).

I'm personally enamoured with the idea of what Dapr is bringing to the table,
and I like the simplicity of using C# 9's Top-level statements to create
applications and micro-services.  These two combined create a wonderfully small
application which could offer a very compelling platform for work.

## Contents

This repo contains two .NET applications:

- `publisher` - A console application for publishing a counter.
- `subscriber` - A Minimal API app using Dapr to store its state, and receive
  updates from the `publisher`.

## Getting Started

Skip steps if you know what you're doing.  😈

1. [Install Dapr](https://docs.dapr.io/getting-started/install-dapr-cli/).
1. [Install Dotnet](https://dotnet.microsoft.com/download/dotnet/6.0) - .NET
    6.0 Preview 7 or later.
1. Initialize Dapr - `dapr init`.
1. Run the subscriber - From the `subscriber` directory, run the app in dapr:
   `dapr run -a dapr-mini-api-sub --app-port 5000 dotnet watch run`
1. Run the publisher - From the `publisher` directory, run the app in dapr:
   `dapr run -a dapr-mini-api-pub dotnet watch run`
1. Profit?  💸
