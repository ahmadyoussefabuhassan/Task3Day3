using Task3Day3.Domain.Abstractions;

namespace Task3Day3.Domain.Products
{
    public sealed class Product : Entity
    {
        private Product(Guid Id, Name name, Price price) : base(Id)
        {
            Name = name;
            Price = price;
        }
        public Name Name { get; private set; } 
        public Price Price { get; private set; }
        public static Product Create(Name name, Price price)
        {
            var product = new Product( Guid.NewGuid(),name, price); 
            return product;
        }
        public void Update(Name name , Price price)
        {
            Name = name;
            Price = price;
        }
    }
}
