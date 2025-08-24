using GambleMaticApi;

using GambleMaticCommLib;

using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);


string? databaseConnectionString = builder.Configuration.GetConnectionString("GambleMaticDatabase");
if (string.IsNullOrEmpty(databaseConnectionString))
{
    throw new Exception("Database connection string is not configured.");
}
builder.Services.AddScoped<DatabaseManager>(_ => new DatabaseManager(databaseConnectionString));

builder.Services.AddGambleMaticCommunicationLibrary();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.MapOpenApi();
app.MapScalarApiReference(options => 
{ 
    options.Title = "Gamblematic V2 API"; 
    options.Theme = ScalarTheme.DeepSpace; 
});
app.UseHttpsRedirection();



app.Run();

