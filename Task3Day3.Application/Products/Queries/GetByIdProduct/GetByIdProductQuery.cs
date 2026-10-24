using Task3Day3.Application.Abstractions.Messaging;

namespace Task3Day3.Application.Products.Queries.GetByIdProduct
{
    public sealed record GetByIdProductQuery(Guid Id) : IQuery<ProductResponse>;
}
