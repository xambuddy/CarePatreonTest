using CarePatreonTest.API;
using Serilog;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
    .UseSerilog();
var app = builder.Build();

app.Run();
