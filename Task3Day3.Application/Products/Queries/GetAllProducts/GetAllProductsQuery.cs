using Task3Day3.Application.Abstractions.Messaging;

namespace Task3Day3.Application.Products.Queries.GetAllProducts
{
    public sealed record GetAllProductsQuery() : IQuery<IEnumerable<ProductsResponse>>;
}
