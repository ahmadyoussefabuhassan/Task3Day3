using Task3Day3.Application.Abstractions.Messaging;
using Task3Day3.Domain.Abstractions;
using Task3Day3.Domain.Products;

namespace Task3Day3.Application.Products.Queries.GetByIdProduct
{
    internal sealed class GetByIdProductQueryHandler : IQueryHandler<GetByIdProductQuery, ProductResponse>
    {
        private readonly IProductRepository _repository;

        public GetByIdProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ProductResponse>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
                return Result.Failure<ProductResponse>(ProductErrors.NotFound);
            var response = new ProductResponse(
                product.Id,
                product.Name.Value,
                product.Price.Value
            );
            return Result.Success(response);
        }
    }
}
