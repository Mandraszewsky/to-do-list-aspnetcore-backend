﻿using MediatR;

namespace ToDoList.Application.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
}