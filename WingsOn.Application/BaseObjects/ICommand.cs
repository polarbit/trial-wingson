using System;
using MediatR;

namespace WingsOn.Application.BaseObjects
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}