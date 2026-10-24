using Task3Day3.Application.Abstractions.Messaging;
using Task3Day3.Domain.Abstractions;
using Task3Day3.Domain.Products;

namespace Task3Day3.Application.Products.Command.DeleteProduct
{
    internal sealed class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            if(product is null)
                return Result.Failure(ProductErrors.NotFound);
            await _productRepository.DeleteAsync(product.Id, cancellationToken);
            return Result.Success();
        }
    }
}
