using Task3Day3.Application.Abstractions.Messaging;
using Task3Day3.Domain.Abstractions;
using Task3Day3.Domain.Products;

namespace Task3Day3.Application.Products.Command.AddProduct
{
    internal sealed class AddProductCommandHandler : ICommandHandler<AddProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<Guid>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(
                new Name(request.Name),
                new Price(request.Price)
            );
            await _productRepository.AddAsync(product , cancellationToken);
            return Result.Success(product.Id);
        }
    }
}
