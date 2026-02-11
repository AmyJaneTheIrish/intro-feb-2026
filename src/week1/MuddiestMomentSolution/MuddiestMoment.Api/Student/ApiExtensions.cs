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
            // 1 hypocrticial
            // 2 "slimed" - "fake user"
            var group = endpoints.MapGroup("/student/moments");
            // If any http post methods come in for /student/moments run this function
            group.MapPost("", StudentAddsMoment.AddMoment);
            group.MapGet("", StudentGetsListOfSavedMoments.GetAllMomentsForStudent);
            // DELETE /student/moments/393849823
            group.MapDelete("/{id:guid}", StudentMarksMomentAnswered.MarkQuestionAnswered);

            // TODO /student/answered-questions
            return group;
        }
    }
}

