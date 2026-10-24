namespace Task3Day3.Domain.Products
{
    public sealed record Name
    {
        public string Value { get; init; }
        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Product name cannot be empty.", nameof(value));
            Value = value;
        }
    }
}
