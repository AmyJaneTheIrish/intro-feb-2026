using Marten;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddOpenApi();
builder.AddNpgsqlDataSource("qa-db");

builder.Services.AddMarten(options =>
{

}).UseNpgsqlDataSource();

var app = builder.Build();

app.MapGet("/greeting", () => "Hello World!"); // TODO: Remove this when you add real endpoints

app.MapOpenApi();
app.MapDefaultEndpoints();
app.Run();