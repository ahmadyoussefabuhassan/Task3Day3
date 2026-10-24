using Task3Day3.Application.Abstractions.Messaging;
using Task3Day3.Domain.Abstractions;
using Task3Day3.Domain.Products;

namespace Task3Day3.Application.Products.Command.UpdateProduct
{
    internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Guid>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (product is null)
                return Result.Failure<Guid>(ProductErrors.NotFound);
            product.Update(
                new Name(request.Name),
                new Price(request.Price)
            );
            await _repository.UpdateAsync(product, cancellationToken);
            return Result.Success(product.Id);    
        }
    }
}
