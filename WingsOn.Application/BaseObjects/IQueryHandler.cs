using MediatR;

namespace WingsOn.Api.Application.BaseObjects
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {

    }
}