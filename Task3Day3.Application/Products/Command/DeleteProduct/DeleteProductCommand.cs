using Task3Day3.Application.Abstractions.Messaging;

namespace Task3Day3.Application.Products.Command.DeleteProduct
{
    public sealed record DeleteProductCommand(Guid Id) : ICommand;
}
