using Infrastructure.Exceptions.Types;

namespace Infrastructure.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception)
    {
        return exception switch
        {
            BusinessException businessException => HandleException(businessException),
            ValidationException validationException => HandleException(validationException),
            NotFoundException notFoundException => HandleException(notFoundException),
            _ => HandleException(exception)
        };
    }
    
    protected abstract Task HandleException(BusinessException businessException);
    protected abstract Task HandleException(NotFoundException notFoundException);
    protected abstract Task HandleException(ValidationException validationException);
    protected abstract Task HandleException(Exception exception);
}