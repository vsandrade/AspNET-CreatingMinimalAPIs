
using MiniValidation;

namespace BeetleMovies.API;

public class ValidateAnnotationFilter : IEndpointFilter
{
  public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
  {
    var movieForCreatingDTO = context.GetArgument<MovieForCreatingDTO>(2);

    if (!MiniValidator.TryValidate(movieForCreatingDTO, out var validationError))
    {
      return TypedResults.ValidationProblem(validationError);
    }

    return await next(context);
  }
}
