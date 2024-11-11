namespace ToDoList.Application.Exceptions;

public abstract class BaseException : Exception
{
    public abstract int HttpCode { get; }

    public BaseException() : base()
    {
    }

    public BaseException(string? message) : base(message)
    {
    }
}