using Task3Day3.Domain.Products;

namespace Task3Day3.Infrastructure.Repositories
{
    internal sealed class ProductRepository : Repository<Product> , IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
