using Microsoft.AspNetCore.Http.HttpResults;

using System.ComponentModel.DataAnnotations;

namespace MuddiestMoment.Api.Student.Endpoints;


/* POST https://localhost:1337/student/moments 

Content-Type: application/json
 
 
{

    "title": "HTTP",

    "description": "More On Resources, plz."

}

*/

public record StudentMomentCreateModel

{

    [MinLength(3), MaxLength(50)]

    public required string Title { get; set; } = string.Empty;

    [MaxLength(150)]

    public string Description { get; set; } = string.Empty;

}

public record StudentMomentResponseModel

{

    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string AddedBy { get; set; } = string.Empty;

    public DateTimeOffset CreatedOn { get; set; }

    public static class StudentAddsMoment

    {

        public static async Task<Ok<StudentMomentResponseModel>> AddMoment(StudentMomentCreateModel request)

        {

            // Get the data sent from the user

            // Make sure they are authenticated

            // add that to database

            // and I'm to send you a receipt

            // this will return an empty 200 Ok status code to the app that called this.

            var response = new StudentMomentResponseModel

            {

                Id = Guid.NewGuid(),

                Title = request.Title,

                Description = request.Description,

                CreatedOn = DateTimeOffset.UtcNow,

                AddedBy = "fake user"

            };

            // Add it to the database and make sure it saves.

            // tomorrow morning, two lines here will save that in the database.

            return TypedResults.Ok(response);

        }

    }

}

