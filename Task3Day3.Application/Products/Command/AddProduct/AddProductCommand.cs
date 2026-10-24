using Task3Day3.Application.Abstractions.Messaging;

namespace Task3Day3.Application.Products.Command.AddProduct
{
    public sealed record AddProductCommand
        (string Name, decimal Price) : ICommand<Guid>;
}
