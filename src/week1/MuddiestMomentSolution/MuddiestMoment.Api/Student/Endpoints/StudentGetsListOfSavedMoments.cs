using Marten;

namespace MuddiestMoment.Api.Student.Endpoints;

public static class StudentGetsListOfSavedMoments
{
    public static async Task<IResult> GetAllMomentsForStudent(IDocumentSession session)
    {
        var moments = await session.Query<StudentMomentEntity>().ToListAsync();

        return TypedResults.Ok(moments);
    }
}
