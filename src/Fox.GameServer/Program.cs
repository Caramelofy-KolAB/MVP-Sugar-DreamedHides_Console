using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSignalR();

// App

var app = builder.Build();

app.MapHub<DreamedHidesHub>("/dreamedHides");

Console.Title = "Fox.GameServer";

Console.WriteLine("\nStarting up server http://localhost:57913...\n");

app.Run();



public class DreamedHidesHub : Hub
{
    public async Task SendPing(int clientNr)
    {
        Console.WriteLine($"[Server] Received Ping from client {clientNr}! Responding with Pong...");
        await Clients.All.SendAsync("ReceivePong", $"Pong - invoked by Client {clientNr}");
    }
}