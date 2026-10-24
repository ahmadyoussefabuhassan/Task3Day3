using Task3Day3.Application.Abstractions.Messaging;

namespace Task3Day3.Application.Products.Command.UpdateProduct
{
    public sealed record UpdateProductCommand(Guid Id, string Name , decimal Price)
        : ICommand<Guid>;
}
