using Task3Day3.Domain.Abstractions;

namespace Task3Day3.Domain.Products
{
    public static class ProductErrors
    {
        public static readonly Error NotFound = new(
              "Product.NotFound", "المنتج المطلوب غير موجود في النظام");
    }
}
