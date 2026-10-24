using Task3Day3.Application.Abstractions.Messaging;
using Task3Day3.Domain.Abstractions;
using Task3Day3.Domain.Products;

namespace Task3Day3.Application.Products.Queries.GetAllProducts
{
    internal sealed class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductsResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<IEnumerable<ProductsResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync(cancellationToken);
            if (!products.Any())
                return Result.Success(Enumerable.Empty<ProductsResponse>());
            var rsponse = products.Select(p => new ProductsResponse(
                p.Id,
                p.Name.Value,
                p.Price.Value
            ));
            return Result.Success(rsponse);
        }
    }
}
