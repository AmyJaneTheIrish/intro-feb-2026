using Marten;

namespace MuddiestMoment.Api.Student.Endpoints;

public static class StudentMarksMomentAnswered
{

    // Who? Authorization..
    // Which question (that id)
    // Policy 
    // - You should only be able to do this for questio you created
    public static async Task<IResult> MarkQuestionAnswered(Guid id, IDocumentSession session)
    {
        // Delete that question from the db
        // See if we can find that moment, and if we do, "flag it" as answered
        var savedMoment = await session.Query<StudentMomentEntity>()
            .Where(m => m.Id == id)
            .SingleOrDefaultAsync();
        if (savedMoment is null)
        {
            return TypedResults.Ok();
        }
        // If the moment exists for this user with this id, update it in the db & mark it as answered
        // Session is life span of HTTP request
        savedMoment.IsAnswered = true;
        session.Store(savedMoment);
        await session.SaveChangesAsync();
        return TypedResults.Ok();

        // Not deleting from the db, just don't want to show it in a certain place anymore
    }
}
