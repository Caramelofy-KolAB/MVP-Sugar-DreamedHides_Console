using Microsoft.AspNetCore.SignalR.Client;

Console.Title = "Fox.Receiver";

Console.WriteLine("------------------------------------------------------------------------------");
Console.WriteLine("\nWelcome to\n \nMVP-Sugar Dreamed Hides console Fox.Receiver\n");
Console.WriteLine("------------------------------------------------------------------------------");

Console.WriteLine("\nConnecting Client to server...\n");

// Hub connection

var hubConnection = new HubConnectionBuilder()
    .WithUrl("http://localhost:57913/dreamedHides")
    .Build();


hubConnection.On<string>("ReceivePong", (message)
    => {
        Console.WriteLine($"[Client] Received from server: {message}");
    });

try
{
    await hubConnection.StartAsync();
    Console.WriteLine("\nClient connected!\n");
}
catch (Exception ex)
{
    Console.WriteLine($"Could not connect to server: {ex.Message}");
    return;
}

Console.WriteLine("\n> Press 'P' on the keyboard to Ping the server. Press any other key to exit");

while (true)
{
    var key = Console.ReadKey(intercept: true).Key;
    if (key == ConsoleKey.P)
    {
        Console.WriteLine("\n[Client] Sending: Ping");
        await hubConnection.InvokeAsync("SendPing", "Fox.Receiver");
    }
    else
    {
        break;
    }
}

// Clean up
await hubConnection.StopAsync();
