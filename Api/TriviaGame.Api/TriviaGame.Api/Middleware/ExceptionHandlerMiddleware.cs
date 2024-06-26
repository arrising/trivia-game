﻿using System.Net;
using Newtonsoft.Json;
using TriviaGame.Api.Exceptions;
using TriviaGame.Api.Models.Dtos;

namespace TriviaGame.Api.Middleware;

/// <summary>
///     Abstract handler for all exceptions.
/// </summary>
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    ///     Gets HTTP status code response and message to be returned to the caller.
    ///     Use the ".Data" property to set the key of the messages if it's localized.
    /// </summary>
    /// <param name="exception">The actual exception</param>
    /// <returns>Tuple of HTTP status code and a message</returns>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            // log the error
            var response = context.Response;
            response.ContentType = "application/json";

            // get the response code and message
            var (status, message) = GetResponse(exception);
            response.StatusCode = (int)status;
            await response.WriteAsync(message);
        }
    }

    public (HttpStatusCode code, string response) GetResponse(Exception exception)
    {
        var code = exception switch
        {
            NotFoundException => HttpStatusCode.NotFound,
            ConversionNullException => HttpStatusCode.InternalServerError,
            ArgumentException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        var response = JsonConvert.SerializeObject(new SimpleErrorDto(exception));

        return (code, response);
    }
}
