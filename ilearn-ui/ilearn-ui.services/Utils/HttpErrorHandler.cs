namespace ilearn_ui.services.Utils
{
    public static class HttpErrorHandler
    {
        public static async Task HandleErrorResponse(HttpResponseMessage httpResponse)
        {
            var content = await httpResponse.Content.ReadAsStringAsync();
            var statusCode = httpResponse.StatusCode;
            if (statusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NotFoundException(content);
            }
            else if (statusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new BadRequestException(content);
            }
            else if (statusCode == System.Net.HttpStatusCode.Forbidden)
            {
                throw new ForbiddenException(content);
            }
            else if (statusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(content);
            }
            else
            {
                throw new Exception($"Error - StatusCode:{statusCode} ErrorMessage:{content}");
            }
        }
    }
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message)
        {
        }
    }
    public class ForbiddenException : Exception
    {
        public ForbiddenException()
        {
        }

        public ForbiddenException(string message)
            : base(message)
        {
        }
    }
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
