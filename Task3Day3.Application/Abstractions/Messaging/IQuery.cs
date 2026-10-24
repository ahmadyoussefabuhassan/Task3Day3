using Task3Day3.Domain.Abstractions;
using MediatR;

namespace Task3Day3.Application.Abstractions.Messaging
{
    public interface IQuery<TResponce> : IRequest<Result<TResponce>>
    {
    }

}
