using MediatR;

namespace WingsOn.Application.BaseObjects
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
