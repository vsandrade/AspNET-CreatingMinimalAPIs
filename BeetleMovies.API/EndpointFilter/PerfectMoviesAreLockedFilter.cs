
namespace BeetleMovies.API;

public class PerfectMoviesAreLockedFilter : IEndpointFilter
{
    public readonly int _lockedPerfectMoviesId;

    public PerfectMoviesAreLockedFilter(int lockedPerfectMoviesId)
    {
      _lockedPerfectMoviesId = lockedPerfectMoviesId;
    }
    
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        int moviesId;

        if (context.HttpContext.Request.Method == "PUT")
        {
          moviesId = context.GetArgument<int>(2);
        }
        else if (context.HttpContext.Request.Method == "DELETE")
        {
          moviesId = context.GetArgument<int>(1);
        }
        else
        {
          throw new NotSupportedException("This filter is not supported for this scenario.");
        }

        var toyStoryId = _lockedPerfectMoviesId;

        if (moviesId == toyStoryId)
        {
          return TypedResults.Problem(new()
          {
            Status = 400,
            Title = "Movie is perfect! You should not change or delete it!",
            Detail = "You can not modify or delete what's already perfect!"
          });
        }

        var result = await next.Invoke(context);
        return result;
    }
}
