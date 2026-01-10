using InventarioCiclico.API.Domain.Exceptions;
using InventarioCiclico.API.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace InventarioCiclico.API.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex) when (!context.Response.HasStarted)
        {
            context.Response.ContentType = "application/problem+json";

            ProblemDetails problem;

            switch (ex)
            {
                case NotFoundException:
                    problem = new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title = "Recurso não encontrado",
                        Detail = ex.Message
                    };
                    break;

                case ValidationException validationEx:
                    problem = new ValidationProblemDetails(
                        new Dictionary<string, string[]>
                        {
                            { "Errors", validationEx.Errors.ToArray() }
                        })
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Title = "Erro de validação"
                    };
                    break;

                case BusinessException:
                    problem = new ProblemDetails
                    {
                        Status = StatusCodes.Status409Conflict,
                        Title = "Conflito de regra de negócio",
                        Detail = ex.Message
                    };
                    break;

                default:
                    problem = new ProblemDetails
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Title = "Erro interno",
                        Detail = "Ocorreu um erro inesperado."
                    };
                    break;
            }

            context.Response.StatusCode = problem.Status ?? StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
