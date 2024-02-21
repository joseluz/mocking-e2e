using FluentAssertions;

namespace MyStore.API.Test
{
    [Collection(nameof(WebAppCollection))]
    public class ProductControllerTests
    {
        private readonly ProductsClient productsClient;

        public ProductControllerTests(CustomWebApplicationFactory factory)
        {
            productsClient = new ProductsClient(factory.CreateClient());
        }

        [Fact]
        public async Task FindAllProducts_WithNoArgs_ShouldReturnAllProducts()
        {
            var products = await productsClient.FindAllAsync();
            products.Should().NotBeEmpty();
            products.Count.Should().BeGreaterThan(4);
            products.Where(p=> p.Name == "Product 5")
                .Should().NotBeNullOrEmpty()
                .And.HaveCount(1);
        }
    }
}