using Task3Day3.Domain.Abstractions;
using MediatR;

namespace Task3Day3.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result> , IBaseCommand
    {
    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>> , IBaseCommand
    {
    }
    public interface IBaseCommand 
    {
    }
}
