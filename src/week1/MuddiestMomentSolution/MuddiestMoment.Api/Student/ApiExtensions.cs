using MuddiestMoment.Api.Student.Endpoints;
using System.Text.RegularExpressions;

namespace MuddiestMoment.Api.Student;

public static class ApiExtensions
{
    extension(IEndpointRouteBuilder endpoints)
    {
        // POST /students/moments
        // GET /student/moments
        public IEndpointRouteBuilder MapStudentEndpoints()
        {
            var group = endpoints.MapGroup("/student/moments");
            // If any http post methods come in for /student/moments run this function
            group.MapPost("", StudentAddsMoment.AddMoment);

            return group;
        }
    }
}

