namespace ToDoList.Application.Exceptions;

public class TaskNotFoundException : BaseException
{
    public override int HttpCode => 404;
    public override string Message => "Object not found in database";
}
