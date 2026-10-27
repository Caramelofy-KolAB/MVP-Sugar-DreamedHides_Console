var builder = WebApplication.CreateBuilder();

// App

var app = builder.Build();

Console.WriteLine("\nStarting up server http://localhost:57913...\n");

app.Run();
