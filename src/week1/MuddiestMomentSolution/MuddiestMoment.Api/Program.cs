// [X] Use Top Level Statements
// In an API project, this is where it starts

using MuddiestMoment.Api.Student;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
// Add the services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// Above this is configuration of services (things that own some state and the process around it) that we need in our application
builder.Services.AddValidation();   // opting in to services to handle some stuff for you
var app = builder.Build();
// Everything here is setting up how we actually handle incoming request & write responses

// Add the code I am about the write that allows us to handle POST to /student/moments

app.MapStudentEndpoints();

app.MapDefaultEndpoints();

// The api is not up and running (listening for requests until we hit the next line)
app.Run();  // "Blocking loop"


// In .NET, when this gets compiled, it creates Assemblies. 