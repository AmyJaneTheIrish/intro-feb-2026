using Marten;

namespace MuddiestMoment.Api.Student.Endpoints;

public static class StudentGetsListOfSavedMoments
{

    // Session here in this particular request list stuff to do to the db
    // It does NONE of that until you call "save changes"
    // When you do that, it will ALL the things you want, or NONE of the things. That is a transaction
    public static async Task<IResult> GetAllMomentsForStudent(IDocumentSession session)
    {
        var moments = await session.Query<StudentMomentEntity>()
            .Where(m => m.AddedBy == "fake user" && m.IsAnswered == false)   // This needs to be he ID of the person making this request
            // Next lines just showing what'll show up in the request
            .Select(m => new StudentMomentResponseModel
            {
                Id = m.Id,
                AddedBy = m.AddedBy,
                CreatedOn = m.CreatedOn,
                Description = m.Description,
                Title = m.Title
            })
            .ToListAsync();


        return TypedResults.Ok(moments);
    }
}
