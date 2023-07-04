using CoffeeClub.Api;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Coffee Club API starting");

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((context, LoggerConfiguration) => LoggerConfiguration
.WriteTo.Console()
.ReadFrom.Configuration(context.Configuration));


var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseSerilogRequestLogging();

await app.ResetDatabaseAsync();


app.Run();

public partial class Program { }
