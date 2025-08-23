using GambleMaticApi;

var builder = WebApplication.CreateBuilder(args);


string? databaseConnectionString = builder.Configuration.GetConnectionString("GambleMaticDatabase");
if (string.IsNullOrEmpty(databaseConnectionString))
{
    throw new Exception("Database connection string is not configured.");
}
builder.Services.AddScoped<DatabaseManager>(_ => new DatabaseManager(databaseConnectionString));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
