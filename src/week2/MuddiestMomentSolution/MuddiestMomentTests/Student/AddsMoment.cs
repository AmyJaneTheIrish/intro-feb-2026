
using Alba;
using MuddiestMoment.Api.Student.Endpoints;
using System.Reflection;

namespace MuddiestMomentTests.Student;

public class AddsMoment
{
    [Fact]
    public async Task CanAddMoment()
    {
        // Starts the program 
        var host = await AlbaHost.For<Program>();

        // Scenario
        // Start up API
        // Make a post request with some data to /student/moments
        // The status code should be a 200.
        // We should also get some stuff back
        // Part 2 later

        var itemToSend = new StudentMomentCreateModel
        {
            Title = "Containers",
            Description = "Tell me about volumes"
        };

        var response = await host.Scenario(api =>
        {
            // Fluent Interface - a "Domain Specific Language"
            api.Post.Json(itemToSend).ToUrl("student/moments");
            api.StatusCodeShouldBeOk();

        });


    }
}

/*POST https://localhost:1337/student/moments
Content-Type: application/json

{
    "title": "Containers",
    "description": "Tell me about volumes"
}

dotnet run // start the api
dotnet test // run my system tests.

*/