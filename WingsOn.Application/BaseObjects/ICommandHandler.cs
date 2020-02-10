using MediatR;

namespace WingsOn.Api.Application.BaseObjects
{
    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand> where TCommand : ICommand
    {

    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {

    }
}