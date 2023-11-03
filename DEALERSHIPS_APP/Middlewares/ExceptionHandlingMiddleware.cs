using DEALERSHIPS_APP.Exceptions;
using FluentValidation;
using Newtonsoft.Json;
using System.Net;

namespace DEALERSHIPS_APP.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

            } catch (ValidationException e) 
            {
                var errors = e.Errors.Select(x => x.ErrorMessage).ToList();
                
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(JsonConvert.SerializeObject(errors));

            } catch (EntityAlreadyExistsException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(e.Message);
            } catch (EntityNotFoundException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsJsonAsync(e.Message);
            }
            
            
            
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(e.Message);
            }
        }
    }
}
