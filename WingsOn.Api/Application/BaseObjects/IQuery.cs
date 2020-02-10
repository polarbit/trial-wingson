using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace WingsOn.Api.Application.BaseObjects
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
