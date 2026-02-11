// [X] Use Top Level Statements
// In an API project, this is where it starts

using Marten;
using MuddiestMoment.Api.Student;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("db-mm") ?? throw new Exception("No Connection String");
// Gonna look in different places to find the connection string "tacos"
// 1st palce is: appsettings.json -> "ConnectionString": { "tacos": "...." } 
// 2nd place is: See if there is an environment variable on the machine you're running on called "ASPNETCORE_ENVIRONMENT"
// Look for an appsettings.Environment.json and use that value (in launchSettings.json)
// 3rd place: Looks at environment variables - ConnectionStrings__tacos

Console.WriteLine($"Using Connection String {connectionString}");
builder.Services.AddMarten(config =>
{
    config.Connection(connectionString);
}).UseLightweightSessions();


builder.AddServiceDefaults();
// Add the services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// Above this is configuration of services (things that own some state and the process around it) that we need in our application
builder.Services.AddValidation();   // opting in to services to handle some stuff for you
var app = builder.Build();
// Everything here is setting up how we actually handle incoming request & write responses

// Add the code I am about the write that allows us to handle POST to /student/moments

app.MapStudentEndpoints(); // More explicit - means more "intention revealing"

app.MapDefaultEndpoints();

// The api is not up and running (listening for requests until we hit the next line)
app.Run();  // "Blocking loop"


// In .NET, when this gets compiled, it creates Assemblies. 